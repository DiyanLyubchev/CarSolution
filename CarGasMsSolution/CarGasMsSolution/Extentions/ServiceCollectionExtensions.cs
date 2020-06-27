using Domain.Application;
using Domain.Factory;
using Domain.Kafka;
using KafkaService;
using KafkaService.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

        public static IApplicationBuilder UseWebService(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            return app;
        }
    }
}
