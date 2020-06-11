using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICarDieselService
    {
        Task<List<CarViewModel>> GetDieselCarAsync();

        Task<int> AddNewCar(CarViewModel carView);

        Task RemoveDieselCarAsync(int carId);
    }
}
