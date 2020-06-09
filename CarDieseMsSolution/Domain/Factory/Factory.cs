using DieselCarDataAccess.Database;
using DieselCarDataAccess.DbManager;
using Domain.Adaptors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Factory
{
    public class Factory : IFactory
    {
        private readonly DieselCarDbContext context;
        public Factory(DieselCarDbContext context)
        {
            this.context = context;
        }

        public IDieselCarDbContextManager GetDieselCarDbManager()
        {
            IDieselCarDbContextManager dbContextManager = new DieselCarDbContextManager(this.context);

            return dbContextManager;
        }

        public Adaptor GetAdaptor()
        {
            return new Adaptor();
        }
    }
}
