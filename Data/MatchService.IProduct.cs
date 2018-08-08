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
        IQueryable<ProductsMatching> GetSubstitutes(string id);
    }

    public partial class MatchService
    {
      
        private ProductDac _productDac;
        internal ProductDac ProductDac => _productDac ?? (_productDac = new ProductDac(_productsRepository));

        private ProductsMatchingDac _productsMatchingDac;
        internal ProductsMatchingDac ProductsMatchingDac => _productsMatchingDac ?? (_productsMatchingDac = new ProductsMatchingDac(_productsRepository));

        public Product GetProduct(string id)
        {
            return ProductDac.GetById(id);
        }

        public IQueryable<Product> ListActiveProducts()
        {
            return ProductDac.ListActive();
        }
        public IQueryable<ProductsMatching> GetSubstitutes(string id)
        {
            return ProductsMatchingDac.ListEntries(id);
        }

    }
}
