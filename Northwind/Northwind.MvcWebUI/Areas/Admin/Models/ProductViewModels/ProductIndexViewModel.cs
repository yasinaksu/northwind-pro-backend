using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.MvcWebUI.Areas.Admin.Models.ProductViewModels
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; }
    }
}