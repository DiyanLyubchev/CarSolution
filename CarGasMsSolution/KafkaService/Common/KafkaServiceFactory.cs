using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaService.Common
{
    public interface IKafkaServiceFactory
    {
        KafkaProducerService GetProducerService(KafkaServerSettings serverSettings, KafkaProducer producer);
    }

    public class KafkaServiceFactory : IKafkaServiceFactory
    {
        public KafkaProducerService GetProducerService(KafkaServerSettings serverSettings, KafkaProducer producer)
        {
            return new KafkaProducerService(serverSettings, producer);
        }
    }
}
