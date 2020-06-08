using Core.Aspects.PostSharp.CacheAspects;
using Core.Aspects.PostSharp.LogAspects;
using Core.Aspects.PostSharp.ValidationAspects;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.DataAccess;
using Northwind.Business.Abstract;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IQueryableRepository<Product> _queryable;

        public ProductManager(IProductDal productDal, IQueryableRepository<Product> queryable)
        {
            _productDal = productDal;
            _queryable = queryable;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public Product GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }
    }
}
