using Domain.Application;
using Domain.Contracts;
using KafkaManagerService;
using KafkaService;
using KafkaService.Common;
using Microsoft.Extensions.DependencyInjection;
using StateMachineDataAccess.DbManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMsSolution.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ResolveServices(this IServiceCollection services)
        {
            services.AddScoped<ICarManager, CarManager>();
            services.AddScoped<IStateMachineDbManager, StateMachineDbManager>();
            return services;
        }

        public static IServiceCollection ResolveKafka(this IServiceCollection services)
        {
            services.AddScoped<IKafkaServiceFactory, KafkaServiceFactory>();
            services.AddScoped<IServiceFactory, KafkaFactory>();
              
            return services;
        }
    }
}
