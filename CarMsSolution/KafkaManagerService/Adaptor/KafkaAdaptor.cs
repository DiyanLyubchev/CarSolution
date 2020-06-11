using Domain.Model;
using KafkaManagerService.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace KafkaManagerService.Adaptor
{
    public class KafkaAdaptor
    {
        public string GetQueryProtocol()
        {
            string message;
            KafkaProtocolModel protocol = new KafkaProtocolModel();
            protocol.Head.Action = "QUERY";
            protocol.Head.Version = "1";

            message = JsonSerializer.Serialize(protocol);

            return message;
        }

        internal string GetAddNewProtocol(CarViewModel car)
        {
            string message;
            KafkaProtocolModel protocol = new KafkaProtocolModel();
            protocol.Head.Action = "ADD_CAR";
            protocol.Head.Version = "1";

            protocol.Data.Add(new KpCarModel
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                EngineType = car.EngineType
            });

            message = JsonSerializer.Serialize(protocol);

            return message;
        }

        public List<CarViewModel> GetCars(string msg)
        {
            KafkaProtocolModel kafkaProtocol = this.GetProtocol(msg);

            return Mapp(kafkaProtocol.Data);
        }

        private List<CarViewModel> Mapp(List<KpCarModel> list)
        {
            return list.Select(car => new CarViewModel
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                EngineType = car.EngineType
            }).ToList();
        }

        private KafkaProtocolModel GetProtocol(string msg)
        {
            return JsonSerializer.Deserialize<KafkaProtocolModel>(msg);
        }
    }
}
