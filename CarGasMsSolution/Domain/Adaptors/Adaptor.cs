using Domain.Model;
using GasCarDataAccess.Database;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Adaptors
{
    public class Adaptor
    {
        public List<CarViewModel> GetCars(List<GasCarTable> list)
        {
            return list.Select(
                car => new CarViewModel
                {
                    CarBrand = car.CarBrand,
                    CarModel = car.CarModel,
                    EngineType = "Бензин"
                }).ToList();
        }

        public CarViewModel MappCarViewModel(KpCarModel car)
        {
            return new CarViewModel
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                EngineType = car.EngineType
            };
        }

        public List<KpCarModel> MappCarViewModel(List<CarViewModel> list)
        {
            return list.Select(
                car => new KpCarModel
                {
                    CarBrand = car.CarBrand,
                    CarModel = car.CarModel,
                    EngineType = car.EngineType
                }).ToList();
        }
    }
}
