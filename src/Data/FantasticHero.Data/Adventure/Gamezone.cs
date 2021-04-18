using System.Collections.Generic;

namespace FantasticHero.Data.Adventure
{
    public class Gamezone : BaseCore
    {
        public int Option { get; set; }
        public string ScenarioName { get; set; }
        public Player Player { get; private set; }
        public List<Hero> Heros { get; set; }
        public List<Monster> Monster { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}
