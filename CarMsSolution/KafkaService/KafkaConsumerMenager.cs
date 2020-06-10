using Confluent.Kafka;
using KafkaService.Common;
using System;
using System.Threading;

namespace KafkaService
{
    public class KafkaConsumerMenager
    {
        private readonly KafkaConsumer kafkaConsumer;
        private readonly string kafkaBoostrapServer;
        private readonly ConsumerConfig config;

        public KafkaConsumerMenager(KafkaConsumer kafkaConsumer, string kafkaBoostrapServer)
        {
            this.kafkaConsumer = kafkaConsumer;
            this.kafkaBoostrapServer = kafkaBoostrapServer;

            config = new ConsumerConfig 
            {
                 GroupId = kafkaConsumer.GroupId,
                 ClientId =kafkaConsumer.ClientId,
                 BootstrapServers = kafkaBoostrapServer,
                 AutoOffsetReset = AutoOffsetReset.Latest
            };
        }


        public string GetMessage() 
        {
            string message = null;

            using (var c = new ConsumerBuilder<Ignore,string>(config)
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .SetStatisticsHandler((_, json) => Console.WriteLine($"Statistics: {json}"))
                .Build())
            {
                c.Subscribe(kafkaConsumer.Topic);

                CancellationTokenSource cts = new CancellationTokenSource();

                try
                {
                    Console.WriteLine($"Cosuming from {kafkaConsumer.Topic}, GroupId " +
                        $"{kafkaConsumer.GroupId}: Name: {c.Name}, Name: {c.MemberId}");

                    var cr = c.Consume(cts.Token);

                    if (cr.IsPartitionEOF)
                    {
                        Console.WriteLine($"Reached end of topic {cr.Topic}, partition {cr.Partition}," +
                            $" offset {cr.Offset}");
                    }
                    else
                    {
                        message = cr.Message.Value;
                        Console.WriteLine($"Consumed message '{message}' at '{cr.TopicPartitionOffset}'");
                    }
                }
                catch (ConsumeException ex)
                {
                    Console.WriteLine($"Error occured: {ex.Error.Reason}");
                }
                catch (Exception)
                {
                }
                c.Close();
            }
            return message;
        }
    }
}
