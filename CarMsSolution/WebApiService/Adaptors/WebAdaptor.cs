using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiService.Models;

namespace WebApiService.Adaptors
{
    public class WebAdaptor
    {
        public CarGasViewModel GetCarGas(CarViewModel car)
        {
            return new CarGasViewModel
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                EngineType = car.EngineType
            };
        }

        public CarDieselViewModel GetCarDiesel(CarViewModel car)
        {
            return new CarDieselViewModel
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                EngineType = car.EngineType
            };
        }

        public List<CarViewModel> Map(List<CarDieselViewModel> list)
        {
            return list.Select(car => new CarViewModel 
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                EngineType = car.EngineType
            }).ToList();
        }

        public List<CarViewModel> Map(List<CarGasViewModel> list)
        {
            return list.Select(car => new CarViewModel
            {
                CarBrand = car.CarBrand,
                CarModel = car.CarModel,
                EngineType = car.EngineType
            }).ToList();
        }
    }
}
