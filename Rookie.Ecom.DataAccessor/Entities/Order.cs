using Rookie.Ecom.DataAccessor.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
        public Guid CustomerAddressId { get; set; }
        public CustomerAddress ShipAddress { get; set; }
    }
}
