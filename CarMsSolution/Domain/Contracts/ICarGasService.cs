using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICarGasService
    {
        Task<List<CarViewModel>> GetGasCarAsync();

        Task<int> AddNewCar(CarViewModel carView);

        Task RemoveGasCarAsync(int carId);
    }
}
