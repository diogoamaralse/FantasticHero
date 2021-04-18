using FantasticHero.Data.Adventure;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FantasticHero.CoreGame.Logic.CoreGame
{
    public class HeroLogic : Hero
    {
        public HeroLogic(GameObjectLogic head, LinkedList<GameObjectLogic> body, GameDirectionsLogic initialHeading, int speed = 1)
        {
            Head = head;
            Body = body;
            Speed = Math.Min(speed, maxSpeed);
            Direction = initialHeading;
            Head.SetHead(Direction.HeadToken);
        }

        private readonly int maxSpeed = 5;
        private readonly int delayMultiplier = 700;

        public GameObjectLogic Head { get; private set; }
        public LinkedList<GameObjectLogic> Body { get; private set; }
        public GameDirectionsLogic Direction { get; private set; }

        public void Move(GameDirectionsLogic direction, GameObjectLogic nextHead)
        {
            var originalHead = Head;

            Direction = direction;

            Head = nextHead;

            Head.SetHead(direction.HeadToken);

            moveBody(originalHead);

            pause();
        }


        private void moveBody(GameObjectLogic originalHead)
        {
            foreach (var cell in Body)
            {
                cell.Decay();
            }
            Body.AddFirst(originalHead);
            Body.RemoveLast();
        }

        private void pause() => Thread.Sleep(maxSpeed - Speed + 1 * delayMultiplier);
    }
}
