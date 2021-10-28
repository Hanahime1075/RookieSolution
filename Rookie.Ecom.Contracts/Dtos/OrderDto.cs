using Rookie.Ecom.DataAccessor.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}
