using Domain.Adaptors;
using GasCarDataAccess.DbManager;

namespace Domain.Factory
{
    public interface IFactory
    {
        Adaptor GetAdaptor();
        IGasCarDbContextManager GetGasCarDbManager();
    }
}