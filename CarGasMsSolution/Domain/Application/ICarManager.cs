using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application
{
    public interface ICarManager
    {
        Task<int> AddNewCarAsync(CarViewModel carViewModel);
        Task DeleteCarAsync(int carId);
        Task<List<CarViewModel>> GetCarsAsync();
    }
}