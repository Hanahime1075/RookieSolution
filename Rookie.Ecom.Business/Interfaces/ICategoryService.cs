using Rookie.Ecom.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    }
}
