using Domain.Adaptors;
using Domain.Application;
using Domain.Factory;
using Domain.Model;
using KafkaService;
using KafkaService.Common;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Kafka
{
    public class DieselCarKafkaConsumer : IKafkaConsumer
    {

        private ICarManager manager;
        private Adaptor adaptor;

        public async Task ProccessMessage(KafkaOptions kafkaOptions, IServiceScope serviceScope, string message)
        {
            IKafkaServiceFactory kafkaFactory = serviceScope.ServiceProvider
                .GetRequiredService<IKafkaServiceFactory>();

            IFactory factory = serviceScope.ServiceProvider
                .GetRequiredService<IFactory>();

            this.manager = new CarManager(factory);
            this.adaptor = factory.GetAdaptor();

            KafkaProducerService producerService = kafkaFactory.GetProducerService
                (
                kafkaOptions.Settings,
                kafkaOptions.Producers[0]
                );

            if (message.Length > 10)
            {
                KafkaProtocolModel kafkaProtocol = this.GetProtocol(message);

                switch (kafkaProtocol.Heap.Action)
                {
                    case "QUERY":
                        await this.ProcessQuery(producerService);
                        break;

                    case "ADD_CAR":
                        await this.ProccessAddCar(kafkaProtocol.Data[0], producerService);
                        break;

                }
            }
            else
            {
                var carID = int.Parse(message);
                await this.RemoveCar(carID);
            }
        }

        private async Task RemoveCar(int carId)
        {
            await this.manager.DeleteCarAsync(carId);
        }

        private async Task ProccessAddCar(KpCarModel kpCar, KafkaProducerService producerService)
        {
            var mappViewModel = this.adaptor.MappCarViewModel(kpCar);

            var id = await this.manager.AddNewCarAsync(mappViewModel);

            string jsonString = JsonSerializer.Serialize(id);

            await producerService.ProduceMessageAsync(jsonString);
        }

        private async Task ProcessQuery(KafkaProducerService producerService)
        {
            var allCars = await this.manager.GetCarsAsync();

            List<KpCarModel> cars = this.adaptor.MappCarViewModel(allCars);

            KafkaProtocolModel kafkaProtocol = new KafkaProtocolModel
            {
                Data = cars,
                Heap = new KpHeapModel
                {
                    Action = "Result",
                    Version = "1"
                }
            };

            string jsonString = JsonSerializer.Serialize(kafkaProtocol);

            await producerService.ProduceMessageAsync(jsonString);
        }

        private KafkaProtocolModel GetProtocol(string message)
        {
            return JsonSerializer.Deserialize<KafkaProtocolModel>(message);
        }
    }
}
