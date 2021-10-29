using AutoMapper;
using FluentAssertions;
using Moq;
using Rookie.Ecom.Business;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.DataAccessor;
using Rookie.Ecom.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.Ecom.UnitTests.Business
{
    public class ProductServiceShould
    {
        private readonly ProductService _productService;
        private readonly Mock<IGenericRepository<Product>> _productRepository;
        private readonly Mock<IGenericRepository<Category>> _categoryRepository;
        private readonly IMapper _mapper;

        public ProductServiceShould()
        {
            _productRepository = new Mock<IGenericRepository<Product>>();
            _categoryRepository = new Mock<IGenericRepository<Category>>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());

            _mapper = config.CreateMapper();

            _productService = new ProductService(
                    _productRepository.Object,
                    _categoryRepository.Object,
                    _mapper
                );
        }

        [Fact]
        public async Task DeleteProductShouldThrowArgumentNullExceptionAsync()
        {
            Guid id = Guid.NewGuid();

            _productRepository.Setup(x => x.GetByIdAsync(id))
                .Returns(Task.FromResult<Product>(null));

            Func<Task> act = async () => await _productService.DeleteAsync(id);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task DeleteProductShouldSuccess()
        {
            Guid id = Guid.NewGuid();
            var entity = new Product()
            {
                Description = "code",
                Id = id,
                ProductName = "Name"
            };
            _productRepository.Setup(x => x.GetByIdAsync(id))
                .Returns(Task.FromResult<Product>(entity));

            Func<Task> act = async () => await _productService.DeleteAsync(id);

            await act.Should().NotThrowAsync();
        }
    }
}
