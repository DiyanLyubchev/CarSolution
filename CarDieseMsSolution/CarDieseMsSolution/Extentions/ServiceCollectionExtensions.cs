using Domain.Application;
using Domain.Factory;
using KafkaService;
using KafkaService.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDieseMsSolution.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ResolveServices(this IServiceCollection services)
        {
            services.AddScoped<IFactory, Factory>();
            services.AddScoped<ICarManager, CarManager>();

            return services;
        }

        public static IServiceCollection ResolveKafka(this IServiceCollection services)
        {
            services.AddScoped<IKafkaServiceFactory, KafkaServiceFactory>();
            services.AddHostedService<KafkaConsumerService>();

            return services;
        }

    }
}
