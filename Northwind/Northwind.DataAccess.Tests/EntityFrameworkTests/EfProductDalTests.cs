using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EfProductDalTests
    {
        //moq cannot be worked do research on google...
        //private List<Product> _products;
        //private Mock<EfProductDal> _mock;
        //private IProductDal _productDal;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    _products = new List<Product>() { new Product(), new Product() };
        //    _mock = new Mock<EfProductDal>();
        //    _mock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Product, bool>>>())).Returns(_products);
        //    _productDal = _mock.Object;
        //}

        //[TestMethod]
        //public void Get_all_returns_all_products()
        //{
        //    var count = _productDal.GetAll(x => x.CategoryId == 1).Count;

        //    Assert.AreEqual(2, count);
        //}

        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetAll();

            Assert.AreEqual(77, result.Count);
        }
    }
}
