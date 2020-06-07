using Core.Entities;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private readonly NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;
        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        //Engin hoca burda virtual yapmamış ?
        public virtual IQueryable<T> Table => this.Entities;

        public virtual IQueryable<T> Entities => _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>());
    }
}
