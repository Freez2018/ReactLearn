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
        IQueryable<RatedProduct> GetSubstitutes(string id);
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
        public IQueryable<RatedProduct> GetSubstitutes(string id)
        {
            // get the avg rates for matching product{
            var subs_Rates = ProductsMatchingDac.ListEntries(id)
                          .GroupBy(t => new { id = t.MatchProductId })
                          .Select(g => new
                          {
                              tasteRate = g.Average(p => p.Rate1),
                              consumeRate = g.Average(p => p.Rate2),
                              priceRate = g.Average(p => p.Rate3),
                              id = g.Key.id                            
                          });

            // join avg rates for product with product details{
            var query = ProductDac.ListActive()    
                        .Join(subs_Rates, 
                         prod => prod.Id,        
                         sub => sub.id,   
                         (prod, sub) => new  
                         {
                             id = prod.Id,
                             name = prod.Name,
                             desc = prod.Description,
                             value = prod.MeasurableValue,
                             category = prod.ProductCategory.Name,
                             tasteRateAvg = sub.tasteRate,
                             consumeRateAvg = sub.consumeRate,
                             priceRateAvg = sub.priceRate                            
                         })
                         .Select( x=> new RatedProduct //selection
                                     {
                                            BaseProdId = id,
                                            Id = x.id,
                                            Name = x.name,
                                            Description = x.desc,
                                            MeasurableValue = x.value,
                                            Category = x.category,
                                            Rate1 = x.tasteRateAvg,
                                            Rate2 = x.consumeRateAvg,
                                            Rate3 = x.priceRateAvg,
                                            totalRate = Math.Round(((x.tasteRateAvg + x.consumeRateAvg + x.priceRateAvg) / 3) * 4, MidpointRounding.ToEven) / 4

                                     })
                         ;

            return query.OrderByDescending(x=>x.totalRate);
        }




    }
}
