using FantasticHero.Abstractions.Entities;
using FantasticHero.Base.Repository;
using FantasticHero.Data.Adventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasticHero.Base.Introduction
{
    public class IntroductionGame : IIntroductionGame
    {

        private readonly IGameZoneRepository _gameZoneRepository;
        private readonly IHeroRepository _heroRepository;

        public IntroductionGame(IGameZoneRepository gameZoneRepository, IHeroRepository heroRepository)
        {
            _gameZoneRepository = gameZoneRepository ?? throw new ArgumentNullException(nameof(gameZoneRepository));
            _heroRepository = heroRepository ?? throw new ArgumentNullException(nameof(heroRepository));
        }

        public string Introduction()
        {
            return @"
-----------------------------------------------------------------------------------------------
______                   _                   _     _            _    _                       
|  ____|                 | |                 | |   (_)          | |  | |                      
| |__      __ _   _ __   | |_    __ _   ___  | |_   _    ___    | |__| |   ___   _ __    ___  
|  __|    / _` | | '_ \  | __|  / _` | / __| | __| | |  / __|   |  __  |  / _ \ | '__|  / _ \ 
| |      | (_| | | | | | | |_  | (_| | \__ \ | |_  | | | (__    | |  | | |  __/ | |    | (_) |
|_|       \__,_| |_| |_|  \__|  \__,_| |___/  \__| |_|  \___|   |_|  |_|  \___| |_|     \___/ 

-----------------------------------------------------------------------------------------------

2021 - Implemented by Diogo Amaral

Welcome! Select a Player Name:";
        }

        public (string, bool) SetPlayerName(string name)
        {
            if (name.Length >= 3)
            {
                return ($"Great {name}! Let's Start", true);

            }

            return ($"Please, select a valid name", false);
        }

        public async Task<List<string>> SetGameZoneAsync()
        {
            List<string> gameZones = new List<string>();
            var gameZoneList = await _gameZoneRepository.GetAllGamezonesAsync();

            gameZones.Add($"Select your favourite GameZone!");

            for (int i = 0; i < gameZoneList.Count(); i++)
            {
                gameZones.Add($"Select {gameZoneList[i].Option } to {gameZoneList[i].ScenarioName}!");
            }

            return gameZones;
        }

        public async Task<Gamezone> LoadGameZoneAsync(int gameZoneOption)
        {
            return await _gameZoneRepository.GetAllGamezonesByOptionIdAsync(gameZoneOption);
        }

        public string InvalidGameZoneMessage()
        {
            return $"You don't select a correct Game Zone! Try again!";
        }

        public async Task<Hero> LoadHeroAsync(int gameZoneOption)
        {
            return await _heroRepository.GetAllHeroOptionIdAsync(gameZoneOption);
        }

        public async Task<List<string>> SetHeroAsync()
        {
            List<string> gameZones = new List<string>();
            var gameZoneList = await _heroRepository.GetAllHerosAsync();

            gameZones.Add($"Select your Hero!");

            for (int i = 0; i < gameZoneList.Count(); i++)
            {
                gameZones.Add($"Select {gameZoneList[i].Option } to {gameZoneList[i].Name}!");
            }

            return gameZones;
        }

        public string InvalidHeroMessage()
        {
            return $"You don't select a correct Hero! Try again!";
        }
    }
}
