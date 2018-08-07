using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Service.Products.Managers
{
    public partial interface IProductsManager
    {
        Product GetProduct(string productId);

        IQueryable<Product> ListActiveProducts(string sortColumn = "name");
    }

    public partial class ProductsManager
    {

        public Product GetProduct(string productId)
        {
            if (productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return MatchService.GetProduct(productId);
        }

        public IQueryable<Product> ListActiveProducts(string sortColumn = "name")
        {
            var queryable = MatchService.ListActiveProducts();
            switch (sortColumn)
            {
                case "nameASC":
                    queryable = Queryable.OrderBy(queryable, x => x.Name);
                    break;

                case "nameDESC":
                    queryable = Queryable.OrderByDescending(queryable, x => x.Name);
                    break;

                default:
                    queryable = queryable.OrderBy(x => x.Name);
                    break;
            }
            return queryable;
        }

    }
}
