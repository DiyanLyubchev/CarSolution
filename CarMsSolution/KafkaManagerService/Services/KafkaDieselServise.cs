using Domain.Contracts;
using Domain.Model;
using KafkaService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KafkaManagerService.Services
{
    public class KafkaDieselServise : ICarDieselService
    {
        private KafkaConsumerMenager consumerMenager;
        private KafkaProducerService KafkaProducerService;
        public KafkaDieselServise(KafkaConsumerMenager consumerMenager, KafkaProducerService kafkaProducerService)
        {
            this.consumerMenager = consumerMenager;
            KafkaProducerService = kafkaProducerService;
        }

        public Task<int> AddNewCar(CarViewModel carView)
        {
            throw new NotImplementedException();
        }

        public Task<List<CarViewModel>> GetDieselCarAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveDieselCarAsync(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
