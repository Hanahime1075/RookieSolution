﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
