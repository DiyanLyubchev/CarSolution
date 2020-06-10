using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IServiceFactory
    {
        ICarDieselService GetCarDieselService();

        ICarGasService GetCarGasService();
    }
}
