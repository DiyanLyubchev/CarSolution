using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaService.Common
{
    public interface IKafkaServiceFactory
    {
        KafkaConsumerMenager GetKafkaConsumerMenager(KafkaConsumer kafkaConsumer, string kafkaBootstrapServer);
        KafkaProducerService GetProducerService(KafkaServerSettings serverSettings, KafkaProducer producer);
    }

    public class KafkaServiceFactory : IKafkaServiceFactory
    {
        public KafkaConsumerMenager GetKafkaConsumerMenager(KafkaConsumer kafkaConsumer, string kafkaBootstrapServer)
        {
            return new KafkaConsumerMenager(kafkaConsumer, kafkaBootstrapServer);
        }
        public KafkaProducerService GetProducerService(KafkaServerSettings serverSettings, KafkaProducer producer)
        {
            return new KafkaProducerService(serverSettings, producer);
        }
    }
}
