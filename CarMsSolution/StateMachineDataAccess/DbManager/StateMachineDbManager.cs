using Microsoft.EntityFrameworkCore;
using StateMachineDataAccess.Database;
using StateMachineDataAccess.Model;
using System.Threading.Tasks;

namespace StateMachineDataAccess.DbManager
{
    public class StateMachineDbManager : IStateMachineDbManager
    {
        private StateMachineDbContext context;

        public StateMachineDbManager(StateMachineDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateStateMachineAsync()
        {
           // var id = await this.GetNextValueAsync();

            var stateMAchine = new StateMachineTable
            {
               // Id = id,
                State = 'P'
            };

            var resultId = await this.context.StateMachines
                 .AddAsync(stateMAchine);
            await this.context.SaveChangesAsync();

            return resultId.Entity.Id;
        }

        public async Task UpdateStateForGasCarAsync(int stateId, int gasCarId)
        {
            var stateMachine = await this.context.StateMachines
                .SingleOrDefaultAsync(id => id.Id == stateId);

            stateMachine.GasCarId = gasCarId;
            stateMachine.State = 'G';

            await this.context.SaveChangesAsync();
        }

        public async Task UpdateStateForDieselCarAsync(int stateId, int dieselCarId)
        {
            var stateMachine = await this.context.StateMachines
                .SingleOrDefaultAsync(id => id.Id == stateId);

            stateMachine.GasCarId = dieselCarId;
            stateMachine.State = 'D';

            await this.context.SaveChangesAsync();
        }

        public async Task UpdateStateSuccessAsync(int stateId)
        {
            var stateMachine = await this.context.StateMachines
                .SingleOrDefaultAsync(id => id.Id == stateId);

            stateMachine.State = 'S';
            await this.context.SaveChangesAsync();
        }

        public async Task<StateMachineDto> TakeCurrentStateAsync(int stateId)
        {
            var stateMachine = await this.context.StateMachines
                .SingleOrDefaultAsync(id => id.Id == stateId);

            return new StateMachineDto
            {
                Id = stateMachine.Id,
                DieselCarId = stateMachine.DieselCarId,
                GasCarId = stateMachine.GasCarId,
                State = stateMachine.State
            };
        }

        private async Task<int> GetNextValueAsync()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"select StateMachineId_seq.NEXTVAL as NEXTVAL from dual";
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
