using Domain.Contracts;
using KafkaManagerService.Services;
using KafkaService;
using KafkaService.Common;
using Microsoft.Extensions.Options;
using System;

namespace KafkaManagerService
{
    public class KafkaFactory : IServiceFactory
    {
        private readonly IKafkaServiceFactory kafkaServiceFactory;
        private readonly KafkaOptions kafkaOptions;

        public KafkaFactory(IKafkaServiceFactory kafkaServiceFactory, IOptions<KafkaOptions> kafkaOptions)
        {
            this.kafkaServiceFactory = kafkaServiceFactory;
            this.kafkaOptions = kafkaOptions.Value;
        }

        public ICarDieselService GetCarDieselService()
        {
            KafkaConsumerMenager consumerMenager = kafkaServiceFactory
                .GetKafkaConsumerMenager(
                kafkaOptions.Consumers[0],
                kafkaOptions.Settings.BootstrapServer
                );

            KafkaProducerService kafkaProducerService = new KafkaProducerService(
                kafkaOptions.Settings,
                kafkaOptions.Producers[1]
                );

            return new KafkaDieselServise(consumerMenager, kafkaProducerService);
        }

        public ICarGasService GetCarGasService()
        {
            KafkaConsumerMenager consumerMenager = kafkaServiceFactory
               .GetKafkaConsumerMenager(
               kafkaOptions.Consumers[0],
               kafkaOptions.Settings.BootstrapServer
               );

            KafkaProducerService kafkaProducerService = new KafkaProducerService(
                kafkaOptions.Settings,
                kafkaOptions.Producers[0]
                );

            return new KafkaGasService(consumerMenager, kafkaProducerService);
        }
    }
}
