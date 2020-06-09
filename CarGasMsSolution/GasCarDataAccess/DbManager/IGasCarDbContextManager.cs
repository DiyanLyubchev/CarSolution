using GasCarDataAccess.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GasCarDataAccess.DbManager
{
    public interface IGasCarDbContextManager
    {
        Task<int> AddNewCarAsync(GasCarTable car);
        Task DeleteAsync(int carId);
        Task<List<GasCarTable>> GetAllCarsAsync();
    }
}