using DieselCarDataAccess.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DieselCarDataAccess.DbManager
{
    public interface IDieselCarDbContextManager
    {
        Task<int> AddNewCarAsync(DieselCarTable car);
        Task DeleteAsync(int carId);
        Task<List<DieselCarTable>> GetAllCarsAsync();
    }
}