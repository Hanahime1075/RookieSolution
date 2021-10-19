using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
