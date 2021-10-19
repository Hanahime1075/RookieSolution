using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid UserName { get; set; }
        public Guid Password { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
        public List<ProductRating> ProductRatings { get; set; }
    }
}
