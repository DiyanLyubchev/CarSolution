using DieselCarDataAccess.DbManager;
using Domain.Adaptors;

namespace Domain.Factory
{
    public interface IFactory
    {
        Adaptor GetAdaptor();
        IDieselCarDbContextManager GetDieselCarDbManager();
    }
}