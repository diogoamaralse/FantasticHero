using FantasticHero.Abstractions.Entities;
using FantasticHero.Abstractions.Entities.Engine;
using FantasticHero.Data.Adventure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FantasticHero.Base.Engine
{
    public class ConsoleAppEngine : IConsoleAppEngine
    {

        private static string characterName;
        private static string gameZone;
        private readonly IIntroductionGame _iGame;
        private readonly int delayBetweenGames = 1500;
        private Gamezone currentGameZone;
        private Hero currentHero;

        public ConsoleAppEngine(IIntroductionGame iGame)
        {
            _iGame = iGame;
        }

        public async Task StartGame()
        {
            SetPlayer();

            await SetGameZone();

            await SetHero();

            ExecutingGame();

        }


        private void SetPlayer()
        {
            //Name Game and First Question
            Console.WriteLine(_iGame.Introduction());

            //Select Name
            characterName = Console.ReadLine();
            (string, bool) PlayerNameMessage = _iGame.SetPlayerName(characterName);
            Console.WriteLine(_iGame.SetPlayerName(characterName).Item1);
            Console.Clear();

            //If invalid name 
            while (PlayerNameMessage.Item2 == false)
            {
                characterName = Console.ReadLine();
                PlayerNameMessage = _iGame.SetPlayerName(characterName);
                Console.WriteLine(_iGame.SetPlayerName(characterName).Item1);
            }
        }

        private async Task SetGameZone()
        {
            //Select Game Zone
            var GameZoneMenu = await _iGame.SetGameZoneAsync();
            for (int i = 0; i < GameZoneMenu.Count; i++)
            {
                Console.WriteLine(GameZoneMenu[i]);
            }
            gameZone = Console.ReadLine();

            bool isValidGameZone = false;

            while (isValidGameZone == false)
            {
                if (int.Parse(gameZone) > 4 || int.Parse(gameZone) < 0)
                {
                    Console.WriteLine(_iGame.InvalidGameZoneMessage());
                    gameZone = Console.ReadLine();
                }
                else
                {
                    isValidGameZone = true;
                }

            }

            currentGameZone = await _iGame.LoadGameZoneAsync(short.Parse(gameZone));

            Console.Clear();
        }

        private async Task SetHero()
        {
            //Select Your Hero
            var Hero = await _iGame.SetHeroAsync();

            for (int i = 0; i < Hero.Count; i++)
            {
                Console.WriteLine(Hero[i]);
            }
            var selectedHero = Console.ReadLine();

            bool isValidHero = false;

            while (isValidHero == false)
            {
                if (int.Parse(gameZone) > 3 || int.Parse(gameZone) < 0)
                {
                    Console.WriteLine(_iGame.InvalidHeroMessage());
                    selectedHero = Console.ReadLine();
                }
                else
                {
                    isValidHero = true;
                }

            }

            currentHero = await _iGame.LoadHeroAsync(short.Parse(selectedHero));

        }

        private void ExecutingGame()
        {
            Run(characterName, currentGameZone.Width, currentGameZone.Height);

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine("\nPress <Enter> to continue...");
                Console.ReadLine();
            }
        }

        public void Run(string characterName, int gameZoneWidth, int gameZoneHeight)
        {
            var finished = false;
            while (!finished)
            {
                var game = new CoreGame.Logic.CoreGame.CoreGame(characterName, gameZoneWidth, gameZoneHeight);
                game.Play();
                finished = game.Quit;
                if (game.Lost)
                {
                    Console.WriteLine("\nYou lost.");
                    Thread.Sleep(delayBetweenGames);
                    Console.Clear();
                }
            }
        }

    }
}
