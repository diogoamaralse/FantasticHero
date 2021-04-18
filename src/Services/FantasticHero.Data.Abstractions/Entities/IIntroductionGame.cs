using FantasticHero.Data.Adventure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FantasticHero.Abstractions.Entities
{
    public interface IIntroductionGame
    {
        string Introduction();
        (string, bool) SetPlayerName(string name);
        Task<List<string>> SetGameZoneAsync();
        Task<Gamezone> LoadGameZoneAsync(int gameZoneOption);
        string InvalidGameZoneMessage();

        Task<List<string>> SetHeroAsync();
        Task<Hero> LoadHeroAsync(int gameZoneOption);
        string InvalidHeroMessage();
    }
}