using FantasticHero.Abstractions.Entities.Engine;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FantasticHero.Provider
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
            services.AddGameSingleton();
            services.AddGameTransient();
            services.AddGameScoped();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ApplicationServices.GetService<IConsoleAppEngine>().StartGame().GetAwaiter().GetResult();
        }
    }
}
