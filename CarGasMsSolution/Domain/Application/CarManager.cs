using Domain.Adaptors;
using Domain.CustomException;
using Domain.Factory;
using Domain.Model;
using GasCarDataAccess.Database;
using GasCarDataAccess.DbManager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application
{
    public class CarManager : ICarManager
    {
        private IGasCarDbContextManager dbContextManager;
        private Adaptor adaptor;

        public CarManager(IFactory factory)
        {
            this.dbContextManager = factory.GetGasCarDbManager();
            this.adaptor = factory.GetAdaptor();
        }

        public async Task<List<CarViewModel>> GetCarsAsync()
        {
            var dieselCars = adaptor.GetCars(await this.dbContextManager.GetAllCarsAsync());

            return dieselCars;
        }

        public async Task<int> AddNewCarAsync(CarViewModel carViewModel)
        {
            if (carViewModel == null)
            {
                throw new CarException("Car cannot be null");
            }

            GasCarTable dieselCar = new GasCarTable
            {
                CarBrand = carViewModel.CarBrand,
                CarModel = carViewModel.CarModel
            };

            var carId = await this.dbContextManager
                .AddNewCarAsync(dieselCar);

            if (carId == 0)
            {
                throw new CarException("Id cannot be zero somthing wrong");
            }
            return carId;
        }

        public async Task DeleteCarAsync(int carId)
        {
            if (carId <= 0)
            {
                throw new CarException("Id cannot be zero or less then zero");
            }

            await this.dbContextManager
                .DeleteAsync(carId);
        }
    }
}
