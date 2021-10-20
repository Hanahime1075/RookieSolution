using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        
        Task<CategoryDto> GetByIdAsync(Guid id);

        Task<CategoryDto> AddAsync(CategoryDto categoryDto);

        Task DeleteAsync(Guid id);

        Task<CategoryDto> UpdateAsync(CategoryDto categoryDto);
    }
}
