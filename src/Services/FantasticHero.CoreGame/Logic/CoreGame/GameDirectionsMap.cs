using FantasticHero.Data.Adventure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FantasticHero.CoreGame.Logic.CoreGame
{
    public class GameDirectionsMap
    {
        private Dictionary<char, GameDirectionsLogic> _directionKeys;
        private Dictionary<char, GameDirectionsLogic> directionKeys
        {
            get
            {
                _directionKeys = _directionKeys ?? directionKeyMap();
                return _directionKeys;
            }
        }

        private Dictionary<eDirections, GameDirectionsLogic> _directionVectors;
        private Dictionary<eDirections, GameDirectionsLogic> directionVectors
        {
            get
            {
                _directionVectors = _directionVectors ?? directionVectorMap();
                return _directionVectors;
            }
        }

        public GameDirectionsLogic Get(char c)
        {
            if (directionKeys.TryGetValue(c, out GameDirectionsLogic direction))
            {
                return direction;
            }
            else
            {
                throw new Exception($"{c} not found in direction map.");
            }
        }

        public GameDirectionsLogic Get(eDirections vector)
        {
            if (directionVectors.TryGetValue(vector, out GameDirectionsLogic direction))
            {
                return direction;
            }
            else
            {
                throw new Exception($"Vector {vector} not found in direction map.");
            }
        }

        public override string ToString() => string.Join(", ", directionVectors.Select(v => v.Value.ToCommand()));

        private Dictionary<eDirections, GameDirectionsLogic> directionVectorMap()
        {
            return new Dictionary<eDirections, GameDirectionsLogic>
            {
                {eDirections.West, new GameDirectionsLogic(eDirections.West , 'a', '<')},
                {eDirections.East, new GameDirectionsLogic(eDirections.East,'d', '>') },
                {eDirections.South, new GameDirectionsLogic(eDirections.South, 's', 'v') },
                {eDirections.North, new GameDirectionsLogic(eDirections.North, 'w', '^') }
            };
        }

        private Dictionary<char, GameDirectionsLogic> directionKeyMap() => directionVectors.ToDictionary(d => d.Value.KeyPress, d => d.Value);
    }
}
