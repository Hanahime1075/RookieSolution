using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string PublisherName { get; set; }
        public string AuthorName { get; set; }
        public int ViewCount { set; get; }
        public Guid CategoryId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductRating> ProductRatings { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
