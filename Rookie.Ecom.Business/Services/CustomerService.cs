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
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _genericRepository;
        private readonly IMapper _mapper;

        public CustomerService(
            IGenericRepository<Customer> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> AddAsync(CustomerDto customerDto)
        {
            Ensure.Any.IsNotNull(customerDto, nameof(customerDto));
            var customer = _mapper.Map<Customer>(customerDto);
            var item = await _genericRepository.AddAsync(customer);
            return _mapper.Map<CustomerDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var result = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(result);
        }

        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            var customer = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public Task<PagedResponseModel<CustomerDto>> PagedQueryAsync(FilterAssignmentsModel filter)
        {
            var query = _genericRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(filter.KeySearch));


            
            }

        public async Task UpdateAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _genericRepository.UpdateAsync(customer);
        }
    }
}
