using StateMachineDataAccess.Model;
using System.Threading.Tasks;

namespace StateMachineDataAccess.DbManager
{
    public interface IStateMachineDbManager
    {
        Task<int> CreateStateMachineAsync();
        Task<StateMachineDto> TakeCurrentStateAsync(int stateId);
        Task UpdateStateForDieselCarAsync(int stateId, int dieselCarId);
        Task UpdateStateForGasCarAsync(int stateId, int gasCarId);
        Task UpdateStateSuccessAsync(int stateId);
    }
}