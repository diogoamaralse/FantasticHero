using FantasticHero.Data.Adventure;
using FantasticHero.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FantasticHero.Base.Repository
{
    public class GameZoneRepository : IGameZoneRepository
    {
        public async Task<List<Gamezone>> GetAllGamezonesAsync()
        {
            List<Gamezone> query;

            using (var context = new GameContext())
            {
                query = await context.GameZones.ToListAsync();

            }

            return query;
        }

        public async Task<Gamezone> GetAllGamezonesByOptionIdAsync(int OptionId)
        {
            Gamezone query;

            using (var context = new GameContext())
            {
                query = await context.GameZones.FirstOrDefaultAsync(x => x.Option == OptionId);

            }

            return query;
        }


    }
}
