using System;
using System.Collections.Generic;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
