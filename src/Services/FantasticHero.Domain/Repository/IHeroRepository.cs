using FantasticHero.Data.Adventure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FantasticHero.Base.Repository
{
    public interface IHeroRepository
    {
        Task<List<Hero>> GetAllHerosAsync();
        Task<Hero> GetAllHeroOptionIdAsync(int OptionId);
    }
}