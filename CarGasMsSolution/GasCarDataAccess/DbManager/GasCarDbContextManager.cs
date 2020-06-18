using GasCarDataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GasCarDataAccess.DbManager
{
    public class GasCarDbContextManager : IGasCarDbContextManager
    {
        private GasCarDbContext context;

        public GasCarDbContextManager(GasCarDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddNewCarAsync(GasCarTable car)
        {
           // int carId = await GetNextValueAsync();

          //  car.Id = carId;

            var newCar = await this.context.GasCars.AddAsync(car);
            await this.context.SaveChangesAsync();


            return newCar.Entity.Id;
        }

        public async Task DeleteAsync(int carId)
        {
            var currentCar = await this.context.GasCars
                .SingleOrDefaultAsync(id => id.Id == carId);

            this.context.GasCars.Remove(currentCar);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<GasCarTable>> GetAllCarsAsync()
        {
            return await this.context.GasCars
                .ToListAsync();
        }

        private async Task<int> GetNextValueAsync()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select GasCarId_seq.NEXTVAL as NEXTVAL from dual";
                context.Database.OpenConnection();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return reader.GetInt32(0);
                }
            }
        }
    }
}
