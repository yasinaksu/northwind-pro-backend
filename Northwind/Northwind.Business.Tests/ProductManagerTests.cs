using AutoMapper;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Northwind.Business.Concrete.Managers;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Add_should_throw_validation_exception_when_unvalid_product_add()
        {
            var mockProductDal = new Mock<IProductDal>();
            var mockMapper = new Mock<IMapper>();
            var productManager = new ProductManager(mockProductDal.Object, mockMapper.Object);
            productManager.Add(new Product());
        }
    }
}
