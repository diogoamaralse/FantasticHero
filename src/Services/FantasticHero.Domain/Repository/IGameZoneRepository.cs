using FantasticHero.Data.Adventure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FantasticHero.Base.Repository
{
    public interface IGameZoneRepository
    {
        Task<List<Gamezone>> GetAllGamezonesAsync();

        Task<Gamezone> GetAllGamezonesByOptionIdAsync(int OptionId);
        
    }
}