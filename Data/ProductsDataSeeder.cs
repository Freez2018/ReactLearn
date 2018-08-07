using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public static class ProductsDataSeeder
    {
        public static void SeedProducts(UsersManagementContext productsRepository)
        {
            if (!productsRepository.ProductCategory.Any())
            {
                var categories = new List<ProductCategory>
                {
                    new ProductCategory
                    {
                        Id = "156eec10-e6aa-4f00-a716-4c1d0d504b6d",
                        Name = "Chocolate",
                        Description = "Chocolate products"
                       
                    },
                    new ProductCategory
                    {
                        Id = "276dbd4c-f918-4860-9909-9c8df5e036fe",
                        Name = "Juice",
                        Description = "Juices"
                    }
                };
                categories.ForEach(x => productsRepository.ProductCategory.Add(x));
                productsRepository.SaveChanges();
            }

            //if (!productsRepository.Product.Any())
            //{
            //    var products = new List<Product>
            //    {
            //        new Product
            //        {
            //            Id = "156eec10-e6aa-4f00-a716-4c1d0d504b6d",
            //            Name = "Chocolate bar",
            //            MeasurableValue = 25
            //        },
            //        new Product
            //        {
            //            Id = "276dbd4c-f918-4860-9909-9c8df5e036fe",
            //            Name = "Casual & Fine Dining"
            //        },
            //        new Product
            //        {
            //            Id = "2ff3eeda-6d1b-49ae-b9dc-d26dd3b6be6c",
            //            Name = "Golf"
            //        },
            //        new Product
            //        {
            //            Id = "85fe3403-bd9f-4053-8ed5-6b0fa6e9cd2c",
            //            Name = "Entertainment"
            //        },
            //        new Product
            //        {
            //            Id = "ab58959a-3f38-4fb9-9bb2-266c0df5e3a0",
            //            Name = "Merchandise & Services"
            //        }
            //    };
            //    products.ForEach(x => productsRepository.Product.Add(x));
            //    productsRepository.SaveChanges();
            //}
        }
    }
}
