using DieselCarDataAccess.Database;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Adaptors
{
    public class Adaptor
    {
        public List<CarViewModel> GetCars(List<DieselCarTable> list)
        {
            return list.Select(
                car => new CarViewModel
                {
                    CarBrand = car.CarBrand,
                    CarModel = car.CarModel,
                    EngineType = "Дизел"
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

        public List<CarViewModel> MappCarViewModel(List<KpCarModel> list)
        {
            return list.Select(
                car => new CarViewModel
                {
                    CarBrand = car.CarBrand,
                    CarModel = car.CarModel,
                    EngineType = car.EngineType
                }).ToList();
        }
    }
}
