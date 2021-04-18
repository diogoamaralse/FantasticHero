using FantasticHero.Data.Adventure;
using FantasticHero.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FantasticHero.Base.Repository
{
    public class HeroRepository : IHeroRepository
    {
        public async Task<Hero> GetAllHeroOptionIdAsync(int OptionId)
        {
            Hero query;

            using (var context = new GameContext())
            {
                query = await context.Heros.FirstOrDefaultAsync(x => x.Option == OptionId);

            }

            return query;
        }

        public async Task<List<Hero>> GetAllHerosAsync()
        {
            List<Hero> query;

            using (var context = new GameContext())
            {
                query = await context.Heros.ToListAsync();
            }

            return query;
        }
    }
}
