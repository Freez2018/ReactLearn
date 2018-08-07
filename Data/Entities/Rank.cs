using Data.Entities;
using System;

namespace Data.Entities
{
    public class Rank : BaseEntity

    {      
        public string DisplayName { get; set; }
        public int Points { get; set; }

    }
}
