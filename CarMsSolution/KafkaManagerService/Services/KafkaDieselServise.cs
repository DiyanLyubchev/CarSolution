﻿using Domain.Contracts;
using Domain.Model;
using KafkaManagerService.Adaptor;
using KafkaService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KafkaManagerService.Services
{
    public class KafkaDieselServise : ICarDieselService
    {
        private KafkaConsumerMenager consumerMenager;
        private KafkaProducerService KafkaProducerService;
        private KafkaAdaptor KafkaAdaptor;

        public KafkaDieselServise(KafkaConsumerMenager consumerMenager, KafkaProducerService kafkaProducerService)
        {
            this.consumerMenager = consumerMenager;
            this.KafkaProducerService = kafkaProducerService;

            this.KafkaAdaptor = new KafkaAdaptor();
        }

        public Task<int> AddNewCar(CarViewModel car)
        {
            string msgCar = null;

            string protocol = KafkaAdaptor.GetAddNewProtocol(car);
            Task taskCar = KafkaProducerService.ProduceMessageAsync(protocol);

            Task<int> taskCar2 = taskCar.ContinueWith(task =>
            {
                msgCar = consumerMenager.GetMessage();

                var currentId = JsonSerializer.Deserialize<int>(msgCar);
                return currentId;
            });

            return taskCar2;
        }

        public Task<List<CarViewModel>> GetDieselCarAsync()
        {
            string msgCar = null;

            string protocol = KafkaAdaptor.GetQueryProtocol();
            Task taskCar = KafkaProducerService.ProduceMessageAsync(protocol);

            Task<List<CarViewModel>> taskCar2 = taskCar.ContinueWith(task =>
            {
                msgCar = consumerMenager.GetMessage();

                List<CarViewModel> cars = KafkaAdaptor.GetCars(msgCar);
                return cars;
            });

            return taskCar2;
        }

        public async Task RemoveDieselCarAsync(int carId)
        {
            var message = JsonSerializer.Serialize(carId);
            await KafkaProducerService.ProduceMessageAsync(message);
        }
    }
}
