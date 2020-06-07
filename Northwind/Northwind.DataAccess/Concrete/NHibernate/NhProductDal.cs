using Core.DataAccess.NHibernate;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Linq;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.ComplexTypes;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        private readonly NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session=_nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>()
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName
                             };
                return result.ToList();
            }
        }
    }
}
