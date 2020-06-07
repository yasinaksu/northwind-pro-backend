using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataAccess.Concrete.NHibernate;
using Northwind.DataAccess.Concrete.NHibernate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NhProductDalTests
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetAll();

            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_all_with_predicate_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetAll(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
