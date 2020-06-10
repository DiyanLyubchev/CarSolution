using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application
{
    public interface ICarManager
    {
        Task AddNewCarAsync(CarViewModel viewModel);
        Task<List<CarViewModel>> GetCarsAsync();
    }
}