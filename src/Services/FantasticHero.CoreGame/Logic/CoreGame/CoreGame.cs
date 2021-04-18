using FantasticHero.Data.Adventure;
using System;
using System.Collections.Generic;

namespace FantasticHero.CoreGame.Logic.CoreGame
{
    public class CoreGame
    {

        //Load all object to play
        public CoreGame(string characterName, int gameZoneWidth, int gameZoneHeight)
        {
            gameZone = new GameZoneLogic(gameZoneWidth, gameZoneHeight);
            var head = gameZone.Center;
            int heroPoints = 2;

            gameZone.AddPlayer(new PlayerLogic(head, initBody(head, heroPoints - 1), directionMap.Get(initialHeading), characterName));


            Random rnd = new Random();

            var randHeros = rnd.Next(2, 5);
            for (int i = 0; i < randHeros; i++)
            {
                gameZone.AddHeros(new HeroLogic(head, initBody(head), directionMap.Get(initialHeading)));

                gameZone.AddMonsters();
            }

            var randMonsters = rnd.Next(2, 10);
            for (int i = 0; i < randMonsters; i++)
            {
                gameZone.AddMonsters(new MonsterLogic(head));

                gameZone.AddMonsters();
            }

            gameZone.DrawGameZone();
        }

        //Default direction
        private readonly eDirections initialHeading = eDirections.North;
        private GameDirectionsMap directionMap = GameZoneLogic.DirectionMap;

        private GameZoneLogic gameZone;
        public bool Lost { get; private set; } = false;
        public bool Quit { get; private set; } = false;


        //Login to read keyboard
        public void Play()
        {
            while (!Lost && !Quit)
            {
                ConsoleKeyInfo input;
                if (Console.KeyAvailable)
                {
                    input = Console.ReadKey(true);
                    try
                    {
                        var direction = directionMap.Get(input.KeyChar);
                        gameZone.DoTurn(direction);
                        Lost = gameZone.HasCollided;
                    }
                    catch
                    {
                        Quit = input.Key == ConsoleKey.Escape;
                    }
                }
                else
                {
                    gameZone.DoTurn();
                    Lost = gameZone.HasCollided;
                }
            }
        }

        private LinkedList<GameObjectLogic> initBody(GameObjectLogic head, int bodyLength = 2)
        {
            var body = new LinkedList<GameObjectLogic>();
            var current = gameZone.BottomNeighbor(head);
            for (var i = 0; i < bodyLength; i++)
            {
                body.AddLast(current);
                current.SetBody(bodyLength - i);
                current = gameZone.BottomNeighbor(current);
            }
            return body;
        }

    }
}
