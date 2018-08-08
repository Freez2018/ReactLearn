using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.QueryableExtensions;
using Client.Service;
using Client.Service.Products.Managers;
using Client.Service.Products.Models;
using Microsoft.AspNetCore.Http;


namespace ReactLearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsManager _ProductsManager;
        public HomeController(IServiceProvider context, IProductsManager productsManager)
        {
            _ProductsManager = productsManager;
        }
        public IActionResult Index()
        {
         // var actives = _ProductsManager.ListActiveProducts("name").ProjectTo<ProductModel>(Mappings.Mapper.ConfigurationProvider).ToList();
            var actives1 = _ProductsManager.ListActiveProducts("name").ToList();

            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
