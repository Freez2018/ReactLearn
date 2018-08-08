using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Client.Service;
using Client.Service.Products.Managers;
using Client.Service.Products.Models;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductsManager _ProductsManager;
        public ProductController(IServiceProvider context, IProductsManager productsManager)
        {           
            _ProductsManager = productsManager;
        }

        // GET: Product
        public ActionResult Index(string sort)
        {
            var actives = _ProductsManager.ListActiveProducts(sort).ToList();
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> ProductsList()
        {           
            return _ProductsManager.ListActiveProducts("Name");
        }
        [HttpGet("[action]")]
        public IEnumerable<ProductsMatching> GetSubstitutes(string id)
        {
            // TODO change to get substitute products
            return _ProductsManager.GetSubstitutes(id);
        }
        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}