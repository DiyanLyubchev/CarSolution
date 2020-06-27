using Domain.Application;
using Domain.Factory;
using Domain.Kafka;
using KafkaService;
using KafkaService.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarGasMsSolution.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ResolveServices(this IServiceCollection services)
        {
            services.AddScoped<IFactory, Factory>();
            services.AddScoped<ICarManager, CarManager>();
            services.AddScoped<IKafkaConsumer, GasCarKafkaConsumer>();
            return services;
        }

        public static IServiceCollection ResolveKafka(this IServiceCollection services)
        {
            services.AddScoped<IKafkaServiceFactory, KafkaServiceFactory>();
            services.AddHostedService<KafkaConsumerService>();

            return services;
        }

        public static IServiceCollection AddDataBase<TDbContext>(
            this IServiceCollection services, IConfiguration configuration)
            where TDbContext : DbContext
            => services
            .AddDbContext<TDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); 
    }
}
