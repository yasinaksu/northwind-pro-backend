using Northwind.Business.Abstract;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //public IHttpActionResult Get()
        //{
        //    return Json(_productService.GetAll());
        //}
        public List<Product> Get()
        {
            return _productService.GetAll();
        }
    }
}
