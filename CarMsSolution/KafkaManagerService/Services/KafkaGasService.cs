using Domain.Contracts;
using Domain.Model;
using KafkaService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KafkaManagerService.Services
{
    public class KafkaGasService : ICarGasService
    {

        private KafkaConsumerMenager consumerMenager;
        private KafkaProducerService KafkaProducerService;
        public KafkaGasService(KafkaConsumerMenager consumerMenager, KafkaProducerService kafkaProducerService)
        {
            this.consumerMenager = consumerMenager;
            KafkaProducerService = kafkaProducerService;
        }

        public Task<int> AddNewCar(CarViewModel carView)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CarViewModel>> GetGasCarAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveGasCarAsync(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
