using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Product : BaseEntity
    {       
        public string Name { get; set; }

        public string Description { get; set; }

        public double MeasurableValue { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual ProductCategory ProductCategory { get; set; }

        public string CategoryId { get; set; }
        public string UserAddedId { get; set; }

    }
}
