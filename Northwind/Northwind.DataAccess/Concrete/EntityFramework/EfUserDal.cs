using Core.DataAccess.EntityFramework;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.ComplexTypes;
using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleDto> GetUserRoles(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from u in context.Users
                             join ur in context.UserRoles
                             on u.Id equals ur.UserId
                             join r in context.Roles
                             on ur.RoleId equals r.Id
                             where u.Id == user.Id
                             select new UserRoleDto
                             {
                                 RoleName = r.Name
                             };

                return result.ToList();
            }
        }
    }
}
