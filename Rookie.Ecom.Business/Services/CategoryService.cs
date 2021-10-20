using AutoMapper;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor;
using Rookie.Ecom.DataAccessor.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using EnsureThat;

namespace Rookie.Ecom.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _genericRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            IGenericRepository<Category> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
            var category = _mapper.Map<Category>(categoryDto);
            var item = await _genericRepository.AddAsync(category);
            return _mapper.Map<CategoryDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var result = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var category = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _genericRepository.UpdateAsync(category);

            var result = await _genericRepository.GetByIdAsync(categoryDto.Id);
            return _mapper.Map<CategoryDto>(result);
        }
    }
}
