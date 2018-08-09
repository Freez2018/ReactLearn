using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{    public class RatedProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MeasurableValue { get; set; }       
        public string Category { get; set; }
        public string BaseProdId { get; set; }
        public double Rate1 { get; set; } // taste
        public double Rate2 { get; set; } // consumption
        public double Rate3 { get; set; } // price
        public double totalRate { get; set; }        

    }
}
