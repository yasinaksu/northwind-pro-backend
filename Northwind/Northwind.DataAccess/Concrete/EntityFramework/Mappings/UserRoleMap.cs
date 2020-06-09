﻿using Northwind.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable(@"UserRoles", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.UserId).HasColumnName("UserId");
            Property(x => x.RoleId).HasColumnName("RoleId");            
        }
    }
}
