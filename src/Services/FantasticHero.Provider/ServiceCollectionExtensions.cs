using FantasticHero.Abstractions.Entities;
using FantasticHero.Abstractions.Entities.Engine;
using FantasticHero.Base.Engine;
using FantasticHero.Base.Introduction;
using FantasticHero.Base.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FantasticHero.Provider
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGameSingleton(this IServiceCollection services)
        {
            services.AddSingleton<IGameZoneRepository, GameZoneRepository>();
            services.AddSingleton<IIntroductionGame, IntroductionGame>();
            services.AddSingleton<IHeroRepository, HeroRepository>();
            services.AddScoped<IConsoleAppEngine, ConsoleAppEngine>();
        }

        public static void AddGameTransient(this IServiceCollection services)
        {

        }

        public static void AddGameScoped(this IServiceCollection services)
        {

        }
    }


}
