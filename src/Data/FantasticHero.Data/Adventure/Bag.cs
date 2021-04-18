using System.Collections.Generic;

namespace FantasticHero.Data.Adventure
{
    public class Bag : BaseCore
    {
        public IEnumerable<Item> Itens { get; set; }
    }
}
