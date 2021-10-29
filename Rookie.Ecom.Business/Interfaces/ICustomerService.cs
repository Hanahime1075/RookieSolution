using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();

        Task<PagedResponseModel<CustomerDto>> PagedQueryAsync(FilterAssignmentsModel filter);

        Task<CustomerDto> GetByIdAsync(Guid id);

        Task<CustomerDto> AddAsync(CustomerDto customerDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(CustomerDto customerDto);
    }
}
