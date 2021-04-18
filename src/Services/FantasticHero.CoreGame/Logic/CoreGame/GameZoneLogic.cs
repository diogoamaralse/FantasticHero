using FantasticHero.Data.Adventure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasticHero.CoreGame.Logic.CoreGame
{
    public class GameZoneLogic : Gamezone
    {
        public GameZoneLogic(int width = 30, int height = 20)
        {
            Width = width;
            Height = height;
            gameObject = new GameObjectLogic[Width, Height];
            initGrid();
        }

        public static GameDirectionsMap DirectionMap { get; } = new GameDirectionsMap();

        private readonly string letsPlay = $"Let's go to play this fantastic Game ";
        private readonly string commands = "Commands: {0}, Esc: Quit\n";

        private GameObjectLogic[,] gameObject;
        private Random random = new Random();
        private int leftEdgeX
        {
            get
            {
                return 0;
            }
        }

        private int rightEdgeX
        {
            get
            {
                return Width - 1;
            }
        }

        private int topEdgeY
        {
            get
            {
                return 0;
            }
        }

        private int bottomEdgeY
        {
            get
            {
                return Height - 1;
            }
        }
        public PlayerLogic PlayerLogic { get; private set; }
        public List<HeroLogic> Hero = new List<HeroLogic>();
        public List<MonsterLogic> MonsterLogic = new List<MonsterLogic>();
        public GameObjectLogic Center
        {
            get
            {
                return get(Width / 2, Height / 2);
            }
        }

        public bool HasCollided { get; private set; }



        public void DoTurn()
        {
            doTurn(PlayerLogic.Direction, getDestination(PlayerLogic.Direction));
        }

        public void DoTurn(GameDirectionsLogic direction)
        {
            doTurn(direction, getDestination(direction));
        }

        public void DrawGameZone()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(ToString());
        }

        public void AddPlayer(PlayerLogic player)
        {
            PlayerLogic = player;
        }

        public void AddHeros(HeroLogic hero)
        {
            Hero.Add(hero);
        }

        public void AddMonsters(MonsterLogic monster)
        {
            MonsterLogic.Add(monster);
        }

        public void AddMonsters()
        {
            randomgameObject().SetMonsters();
        }

        public GameObjectLogic TopNeighbor(GameObjectLogic gameObject)
        {
            return this.gameObject[gameObject.X, gameObject.Y - 1];
        }

        public GameObjectLogic RightNeighbor(GameObjectLogic gameObject)
        {
            return this.gameObject[gameObject.X + 1, gameObject.Y];
        }

        public GameObjectLogic BottomNeighbor(GameObjectLogic gameObject)
        {
            return this.gameObject[gameObject.X, gameObject.Y + 1];
        }

        public GameObjectLogic LeftNeighbor(GameObjectLogic gameObject)
        {
            return this.gameObject[gameObject.X - 1, gameObject.Y];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    sb.Append(gameObject[x, y].Value);
                }
                sb.Append("\n");
            }

            sb.AppendLine(letsPlay);
            sb.AppendFormat(commands, DirectionMap.ToString());
            return sb.ToString();
        }

        private GameObjectLogic get(int x, int y)
        {
            return gameObject[x, y];
        }

        private void add(GameObjectLogic gameObject)
        {
            this.gameObject[gameObject.X, gameObject.Y] = gameObject;
        }

        private bool isBorder(GameObjectLogic gameObject)
        {
            return gameObject.X == leftEdgeX
                || gameObject.X >= rightEdgeX
                || gameObject.Y == topEdgeY
                || gameObject.Y >= bottomEdgeY;
        }

        private void doTurn(GameDirectionsLogic direction, GameObjectLogic target)
        {
            PlayerLogic.Move(direction, target);
            DrawGameZone();

        }

        private GameObjectLogic getDestination(GameDirectionsLogic direction)
        {
            return getDirectionalNeighbor(PlayerLogic.Head, direction);
        }

        private GameObjectLogic getDirectionalNeighbor(GameObjectLogic gameObject, GameDirectionsLogic direction)
        {
            var neighbor = new GameObjectLogic(-1, -1);

            if (direction.IsNorth)
            {
                neighbor = TopNeighbor(gameObject);
            }
            else if (direction.IsEast)
            {
                neighbor = RightNeighbor(gameObject);
            }
            else if (direction.GetIsSouth())
            {
                neighbor = BottomNeighbor(gameObject);
            }
            else if (direction.GetIsWest())
            {
                neighbor = LeftNeighbor(gameObject);
            }

            return neighbor;
        }

        private GameObjectLogic randomgameObject()
        {
            bool isEmpty;
            var gameObject = new GameObjectLogic(-1, -1);
            do
            {
                gameObject = this.gameObject[random.Next(Width), random.Next(Height)];
                isEmpty = gameObject.IsEmpty;
            } while (!isEmpty);

            return gameObject;
        }

        private void initGrid()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var gameObject = new GameObjectLogic(x, y);

                    add(gameObject);

                    if (isBorder(gameObject))
                    {
                        gameObject.SetBorder();
                    }
                    else
                    {
                        gameObject.SetEmpty();
                    }
                }
            }
        }
    }
}
