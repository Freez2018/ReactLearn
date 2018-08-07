using System;
using AutoMapper;
using Client.Service.Products.Models;
using Data.Entities;

namespace Client.Service
{
    public class Mappings
    {
        public static IMapper Mapper { get; set; }

        public static void ConfigureMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                /* Products */
              
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();

               //  cfg.CreateMap<Product, ProductDetailViewModel>();
               // cfg.CreateMap<ProductModel, ProductDetailViewModel>();

                /* end Products */

            });
            Mapper = config.CreateMapper();
        }
    }
}
