using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Service.Products.Models
{
    public class ProductModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateDisabled { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MeasurableValue { get; set; }
        public string UserAddedId { get; set; }
        public string CategoryId { get; set; }
        public string Id { get; set; }
        public bool IsActive => this.DateDisabled == null;

    }
}
