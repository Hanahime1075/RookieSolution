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
        public async Task GetAsyncShouldReturnNullAsync()
        {
            Guid id = Guid.NewGuid();

            Guid id2 = Guid.NewGuid();

            var entity = new Category()
            {
                Description = "code",
                Id = id2,
                Name = "Name"
            };

            List<Category> categories = new List<Category>();
            categories.Add(entity);
            _categoryRepository
                  .Setup(x => x.GetByIdAsync(id))
                  .Returns(Task.FromResult<Category>(null));

            var result = await _categoryService.GetByIdAsync(id);
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAsyncShouldReturnObjectAsync()
        {
            //Arrange
            Random rnd = new Random();
            Guid id = Guid.NewGuid();
            var entity = new Category()
            {
                Description = "code",
                Id = id,
                Name = "Name"
            };

            List<Category> categories = new List<Category>();
            categories.Add(entity);

            _categoryRepository.Setup(x => x.GetByIdAsync(entity.Id)).Returns(Task.FromResult(entity));

            //Act
            var result = await _categoryService.GetByIdAsync(entity.Id);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(entity.Id);

            _categoryRepository.Verify(mock => mock.GetByIdAsync(entity.Id), Times.Once);
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnList()
        {
            //Arrange
            Random rnd = new Random();
            Guid id = Guid.NewGuid();
            var entity = new Category()
            {
                Description = "code",
                Id = id,
                Name = "Name"
            };

            IList<Category> categories = new List<Category>()
                 { new Category()
            {
                Description = "code",
                Id = id,
                Name = "Name"
            }};

            //Act
            var result = await _categoryService.GetAllAsync();
            //Assert

            result.Should().NotBeNull();
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
            Random rnd = new Random();

            Guid id = Guid.NewGuid();

            Guid id2;
            do
            {
                id2 = Guid.NewGuid();
            } while (id == id2);

            var category = new Category()
            {
                Description = "code",
                Id = id,
                Name = "name"
            };

            var categoryDto = new CategoryDto()
            {
                Desc = "code",
                Id = id2,
                Name = "name"
            };
            _categoryRepository.Setup(x => x
                .GetByAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                .Returns(Task.FromResult<Category>(category));

            _categoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<Category>(null));

            _categoryRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).Returns(Task.FromResult(category));

            var result = await _categoryService.AddAsync(categoryDto);

            result.Should().NotBeNull();

            _categoryRepository.Verify(mock => mock.AddAsync(It.IsAny<Category>()), Times.Once());
        }

        [Fact]
        public async Task AddCategoryShouldThrowArgumentExceptionAsync()
        {
            Random rnd = new Random();

            Guid id = Guid.NewGuid();

            //int id2 = id;

            var category = new Category()
            {
                Description = "code",
                Id = id,
                Name = "name"
            };

            var categoryDto = new CategoryDto()
            {
                Desc = "code",
                Id = id,
                Name = "name"
            };

            _categoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(category));

            Func<Task> act = async () => await _categoryService.AddAsync(categoryDto);
            await act.Should().ThrowAsync<ArgumentException>();

            _categoryRepository.Verify(mock => mock.AddAsync(It.IsAny<Category>()), Times.Never());
        }


        [Fact]
        public async Task DeleteCategoryShouldThrowArgumentNullExceptionAsync()
        {
            Random rnd = new Random();
            Guid id = Guid.NewGuid();

            _categoryRepository.Setup(x => x.GetByIdAsync(id))
                .Returns(Task.FromResult<Category>(null));

            Func<Task> act = async () => await _categoryService.DeleteAsync(id);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task DeleteCategoryShouldSuccess()
        {
            Random rnd = new Random();
            Guid id = Guid.NewGuid();
            var entity = new Category()
            {
                Description = "code",
                Id = id,
                Name = "Name"
            };
            _categoryRepository.Setup(x => x.GetByIdAsync(id))
                .Returns(Task.FromResult<Category>(entity));

            Func<Task> act = async () => await _categoryService.DeleteAsync(id);

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateCategoryShouldSuccess()
        {
            //Arrange
            Random rnd = new Random();
            Guid id = Guid.NewGuid();
            var categoryDto = new CategoryDto()
            {
                Desc = "code",
                Id = id,
                Name = "Name"
            };

            var category = new Category()
            {
                Description = "code",
                Id = id,
                Name = "Name"
            };

            _categoryRepository.Setup(x => x.GetByIdAsync(categoryDto.Id))
                .Returns(Task.FromResult<Category>(category));

            //Act
            var res = await _categoryService.UpdateAsync(categoryDto);

            //Assert
            res.Should().NotBeNull();
        }
    }
}
