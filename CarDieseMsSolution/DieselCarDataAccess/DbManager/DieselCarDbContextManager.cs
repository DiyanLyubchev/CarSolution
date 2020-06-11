using DieselCarDataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DieselCarDataAccess.DbManager
{
    public class DieselCarDbContextManager : IDieselCarDbContextManager
    {
        private DieselCarDbContext context;

        public DieselCarDbContextManager(DieselCarDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddNewCarAsync(DieselCarTable car)
        {
            int carId = await this.GetNextValueAsync();

            car.Id = carId;

            var newCar = await this.context.DieselCars.AddAsync(car);
            await this.context.SaveChangesAsync();


            return newCar.Entity.Id;
        }

        public async Task DeleteAsync(int carId)
        {
            var currentCar = await this.context.DieselCars
                .SingleOrDefaultAsync(id => id.Id == carId);

            this.context.DieselCars.Remove(currentCar);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<DieselCarTable>> GetAllCarsAsync()
        {
            return await this.context.DieselCars
                .ToListAsync();
        }

        private async Task<int> GetNextValueAsync()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select DieselCarId_seq.NEXTVAL as NEXTVAL from dual";
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

