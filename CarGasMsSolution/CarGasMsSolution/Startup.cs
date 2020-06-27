using CarGasMsSolution.Extentions;
using GasCarDataAccess.Database;
using KafkaService.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarGasMsSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDataBase<GasCarDbContext>(this.Configuration);
            services.ResolveServices();

            services.Configure<KafkaOptions>(Configuration.GetSection("KafkaOptions"));
            services.ResolveKafka();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
              => app.UseWebService(env);
    }
}
