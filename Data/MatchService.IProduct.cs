using Data.Dac;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public partial interface IMatchService : IProductService
    {
    }

    public interface IProductService
    {
        Product GetProduct(string id);
        IQueryable<Product> ListActiveProducts();
    }

    public partial class MatchService
    {
      
        private ProductDac _productDac;
        internal ProductDac ProductDac => _productDac ?? (_productDac = new ProductDac(_productsRepository));

        public Product GetProduct(string id)
        {
            return ProductDac.GetById(id);
        }

        public IQueryable<Product> ListActiveProducts()
        {
            return ProductDac.ListActive();
        }

    }
}
