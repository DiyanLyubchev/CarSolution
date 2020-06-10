using KafkaService;
using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaManagerService.Services
{
    public class KafkaDieselServise
    {
        private KafkaConsumerMenager consumerMenager;
        private KafkaProducerService KafkaProducerService;
        public KafkaDieselServise(KafkaConsumerMenager consumerMenager, KafkaProducerService kafkaProducerService)
        {
            this.consumerMenager = consumerMenager;
            KafkaProducerService = kafkaProducerService;
        }
    }
}
