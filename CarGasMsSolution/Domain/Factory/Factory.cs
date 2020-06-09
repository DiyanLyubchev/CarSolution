using Domain.Adaptors;
using GasCarDataAccess.Database;
using GasCarDataAccess.DbManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Factory
{
    public class Factory : IFactory
    {
        private readonly GasCarDbContext context;
        public Factory(GasCarDbContext context)
        {
            this.context = context;
        }

        public IGasCarDbContextManager GetGasCarDbManager()
        {
            IGasCarDbContextManager dbContextManager = new GasCarDbContextManager(this.context);

            return dbContextManager;
        }

        public Adaptor GetAdaptor()
        {
            return new Adaptor();
        }
    }
}
