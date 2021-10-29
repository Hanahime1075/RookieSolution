using AutoMapper;
using FluentAssertions;
using Moq;
using Rookie.Ecom.Business;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Dtos;
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
    public class CategoryServiceShould
    {
        private readonly CategoryService _categoryService;
        private readonly Mock<IGenericRepository<Category>> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServiceShould()
        {
            _categoryRepository = new Mock<IGenericRepository<Category>>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

            _categoryService = new CategoryService(
                    _categoryRepository.Object,
                    _mapper
                );
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnNullAsync()
        {
            Guid id = Guid.NewGuid();

            var entity = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Description = "Test 1"
            };

            List<Category> categories = new List<Category>();
            categories.Add(entity);
            _categoryRepository
                  .Setup(x => x.GetByIdAsync(id))
                  .Returns(Task.FromResult<Category>(null));

            _categoryRepository
                  .Setup(x => x.GetAll())
                  .Returns(categories);

            var result = await _categoryService.GetByIdAsync(id);
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnListAsync()
        {
            var entity = new Category()
            {
                Description = "code",
                Id = Guid.NewGuid(),
                Name = "Name"
            };

            List<Category> categories = new List<Category>();
            categories.Add(entity);

            _categoryRepository
                 .Setup(x => x.GetAll())
                 .Returns(categories);

            _categoryRepository.Setup(x => x.GetByIdAsync(entity.Id)).Returns(Task.FromResult(entity));

            var result = await _categoryService.GetByIdAsync(entity.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(entity.Id);

            _categoryRepository.Verify(mock => mock.GetByIdAsync(entity.Id), Times.Once);
        }

        [Fact]
        public async Task GetAsyncShouldReturnNullAsync()
        {
            var id = Guid.NewGuid();
            _categoryRepository
                  .Setup(x => x.GetByIdAsync(id))
                  .Returns(Task.FromResult<Category>(null));

            var result = await _categoryService.GetByIdAsync(id);
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAsyncShouldReturnObjectAsync()
        {
            var entity = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Description = "Test 1"
            };

            _categoryRepository.Setup(x => x.GetByIdAsync(entity.Id)).Returns(Task.FromResult(entity));
            var result = await _categoryService.GetByIdAsync(entity.Id);
            result.Should().NotBeNull();
            result.Id.Should().Be(entity.Id);

            _categoryRepository.Verify(mock => mock.GetByIdAsync(entity.Id), Times.Once);
        }

        [Fact]
        public async Task AddCategoryShouldThrowExceptionAsync()
        {
            Func<Task> act = async () => await _categoryService.AddAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task AddCategoryShouldBeSuccessfullyAsync()
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                Description = "Test 1"
            };

            var categoryDto = new CategoryDto()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                Desc = "Test 1"
            };

            _categoryRepository.Setup(x => x
                .GetByAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                .Returns(Task.FromResult<Category>(category));

            _categoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult<Category>(null));

            _categoryRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).Returns(Task.FromResult(category));

            var result = await _categoryService.AddAsync(categoryDto);

            result.Should().NotBeNull();

            _categoryRepository.Verify(mock => mock.AddAsync(It.IsAny<Category>()), Times.Once());
        }

        [Fact]
        public async Task UpdateCategoryShouldThrowExceptionAsync()
        {
            Func<Task> act = async () => await _categoryService.UpdateAsync(null);
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task DeleteCategoryShouldBeSuccessfullyAsync()
        {
            Guid id = Guid.NewGuid();
            var entity = new Category()
            {
                Id = id,
                Name = "Name",
                Description = "Test 1"
            };
            _categoryRepository.Setup(x => x.GetByIdAsync(id))
                .Returns(Task.FromResult<Category>(entity));

            Func<Task> act = async () => await _categoryService.DeleteAsync(id);

            await act.Should().NotThrowAsync();
        }
    }
}
