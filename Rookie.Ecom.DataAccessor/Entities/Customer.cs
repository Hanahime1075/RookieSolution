using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Img { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }

        public List<CustomerAddress> CustomerAddresses { get; set; }
    }
}
