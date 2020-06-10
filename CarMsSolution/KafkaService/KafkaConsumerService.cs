using System;

namespace KafkaService
{
    public class KafkaConsumerService : BackgroundService
    {
        private readonly KafkaOptions kafkaOptions;
        private readonly IServiceProvider serviceProvider;
        private ConsumerConfig conf;
        private KafkaConsumer KafkaConsumer;

        public KafkaConsumerService(IOptions<KafkaOptions> kafkaOptions, IServiceProvider serviceProvider)
        {
            KafkaConsumer = kafkaOptions.Value.Consumers[0];
            conf = new ConsumerConfig
            {
                GroupId = KafkaConsumer.GroupId,
                ClientId = KafkaConsumer.ClientId,
                BootstrapServers = kafkaOptions.Value.Settings.BootstrapServer,
                AutoOffsetReset = AutoOffsetReset.Latest
            };
            this.kafkaOptions = kafkaOptions.Value;
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(
                () => this.StartConsumer(stoppingToken));
        }

        private async Task StartConsumer(CancellationToken stoppingToken)
        {
            Console.WriteLine($"StartConsumer...");
            using (var consumer = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                consumer.Subscribe(KafkaConsumer.Topic);

                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        Console.WriteLine($"Consuming from  {KafkaConsumer.Topic}," +
                            $" GroupId {KafkaConsumer.GroupId}: Name: {consumer.Name}, MemberId: {consumer.MemberId}");

                        var resultConsumer = consumer.Consume(stoppingToken);

                        Console.WriteLine($"Consumed '{resultConsumer.Message.Value}' at: '{resultConsumer.TopicPartitionOffset}' .");

                        if (!string.IsNullOrEmpty(resultConsumer.Message.Value))
                        {
                            using (IServiceScope scope = serviceProvider.CreateScope())
                            {
                                var context = scope.ServiceProvider
                                    .GetRequiredService<IKafkaConsumer>();

                                await context.ProccessMessage(kafkaOptions, scope, resultConsumer.Message.Value);
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    catch (Exception)
                    {
                    }
                }
                consumer.Close();
            }
        }
    }
}
