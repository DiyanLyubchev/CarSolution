using Domain.Model;
using System.Collections.Generic;
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
