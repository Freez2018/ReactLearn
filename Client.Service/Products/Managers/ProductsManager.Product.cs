using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Service.Products.Managers
{
    public partial interface IProductsManager
    {
        Product GetProduct(string productId);
    }

    public partial class ProductsManager
    {

        public Product GetProduct(string productId)
        {
            if (productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return ProductService.GetProduct(productId);
        }

    }
}
