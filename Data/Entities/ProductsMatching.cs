using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class ProductsMatching : BaseEntity 
    {
        [ForeignKey(nameof(BaseProductId))]
        public virtual Product BaseProduct { get; set; }
        public string BaseProductId { get; set; }
        [ForeignKey(nameof(MatchProductId))]
        public virtual Product MatchProduct { get; set; }
        public string MatchProductId { get; set; } 

        public double Rate1 { get; set; } // taste
        public double Rate2 { get; set; } // consumption
        public double Rate3 { get; set; } // price

        public string UserAddedId { get; set; }
    }
}
