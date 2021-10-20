using System;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string PublisherName { get; set; }
        public string AuthorName { get; set; }
        public int ViewCount { set; get; }
        public Guid CategoryId { get; set; }
    }
}
