using Domain.Contracts;
using Microsoft.Extensions.Options;
using System;
using WebApiService.Services.Common;
using WebApiService.Services.DieselService;
using WebApiService.Services.GasService;

namespace WebApiService
{
    public class WebServiceFactory : IServiceFactory
    {
        private readonly ServiceOptions serviceOptions;

        public WebServiceFactory(IOptions<ServiceOptions> serviceOptions)
        {
            this.serviceOptions = serviceOptions.Value;
        }

        public ICarDieselService GetCarDieselService()
        {
            return new DieselCarApiService(this.serviceOptions.CarDieselServiceUrl);
        }

        public ICarGasService GetCarGasService()
        {
            return new GasCarApiService(this.serviceOptions.CarGasServiceUrl);
        }
    }
}
