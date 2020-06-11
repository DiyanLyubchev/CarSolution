using DieselCarDataAccess.Database;
using DieselCarDataAccess.DbManager;
using Domain.Adaptors;
using Domain.CustomException;
using Domain.Factory;
using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application
{
    public class CarManager : ICarManager
    {
        private IDieselCarDbContextManager dbContextManager;
        private Adaptor adaptor;

        public CarManager(IFactory factory)
        {
            this.dbContextManager = factory.GetDieselCarDbManager();
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

            DieselCarTable dieselCar = new DieselCarTable
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
