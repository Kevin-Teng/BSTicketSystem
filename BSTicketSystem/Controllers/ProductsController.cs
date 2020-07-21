using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BSTicketSystem.Interface;
using BSTicketSystem.Models;
using BSTicketSystem.Service;

namespace BSTicketSystem.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService productService;

        public ProductsController()
        {
            productService = new ProductService();
        }
        public ActionResult Index()
        {
            var products = productService.GetAll();
            return View(products);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var product = productService.GetById(id.Value);
                return View(product);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (product != null && ModelState.IsValid)
            {
                productService.Create(product);
                return RedirectToAction("index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var product = productService.GetById(id.Value);
                return View(product);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (product != null && ModelState.IsValid)
            {
                productService.Update(product);
                return View(product);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var product = productService.GetById(id.Value);
                return View(product);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = productService.GetById(id);
                productService.Delete(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("index");
        }

    }
}
