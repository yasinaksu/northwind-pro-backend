using Northwind.Business.Abstract;
using Northwind.MvcWebUI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var model = new ProductIndexViewModel { Products = _productService.GetAll() };
            return View(model);
        }
    }
}