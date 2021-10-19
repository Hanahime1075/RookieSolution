using AutoMapper;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor;
using Rookie.Ecom.DataAccessor.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Rookie.Ecom.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            IGenericRepository<Category> genericRepository,
            IGenericRepository<Product> productRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var result = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var result = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
    }
}
