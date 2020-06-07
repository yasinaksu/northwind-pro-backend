using Core.DataAccess.NHibernate;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        private readonly NHibernateHelper _nHibernateHelper;
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }
    }
}
