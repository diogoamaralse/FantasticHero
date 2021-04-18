using System;
using System.ComponentModel.DataAnnotations;

namespace FantasticHero.Data.Adventure
{
    public class BaseCore
    {
        [Key]
        public Guid CoreObjectID { get; set; }
    }
}
