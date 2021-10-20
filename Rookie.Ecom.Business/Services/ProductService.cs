using AutoMapper;
using EnsureThat;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor;
using Rookie.Ecom.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public ProductService(
            IGenericRepository<Product> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto, nameof(productDto));
            var product = _mapper.Map<Product>(productDto);
            var item = await _genericRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var result = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _genericRepository.UpdateAsync(product);
        }
    }
}
