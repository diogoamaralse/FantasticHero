using FantasticHero.Data.Adventure;
using System;

namespace FantasticHero.CoreGame.Logic.CoreGame
{
    public class GameDirectionsLogic
    {
        public GameDirectionsLogic(eDirections vector, char keyPress, char headToken)
        {
            Directions = vector;
            KeyPress = keyPress;
            HeadToken = headToken;
        }

        public eDirections Directions { get; private set; }
        public char KeyPress { get; private set; }
        public char HeadToken { get; private set; }
        public int Degrees
        {
            get
            {
                return (int)Directions;
            }
        }

        public GameDirectionsLogic Opposite
        {
            get
            {
                return GameZoneLogic.DirectionMap.Get((eDirections)(Degrees >= 180 ? Degrees - 180 : Degrees + 180));
            }
        }

        public bool IsNorth
        {
            get
            {
                return Directions == eDirections.North;
            }
        }

        public bool IsEast
        {
            get
            {
                return Directions == eDirections.East;
            }
        }

        public bool GetIsSouth()
        {
            return Directions == eDirections.South;
        }

        public bool GetIsWest()
        {
            return Directions == eDirections.West;
        }

        public bool IsOpposite(GameDirectionsLogic dir)
        {
            return Math.Abs(Degrees - dir.Degrees) == 180;
        }

        public bool IsSame(GameDirectionsLogic dir)
        {
            return Directions == dir.Directions;
        }

        public string ToCommand()
        {
            return $"{KeyPress}: {Directions}";
        }
    }
}
