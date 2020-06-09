﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Domains
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
