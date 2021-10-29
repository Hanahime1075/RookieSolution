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
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _genericRepository;
        private readonly IMapper _mapper;

        public OrderService(
            IGenericRepository<Order> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> AddAsync(OrderDto orderDto)
        {
            Ensure.Any.IsNotNull(orderDto, nameof(orderDto));
            var order = _mapper.Map<Order>(orderDto);
            var item = await _genericRepository.AddAsync(order);
            return _mapper.Map<OrderDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var result = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(result);
        }

        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var order = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(order);
        }

        public Task<PagedResponseModel<OrderDto>> PagedQueryAsync(FilterAssignmentsModel filter)
        {
            var query = _genericRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(filter.KeySearch));



        }

        public async Task UpdateAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _genericRepository.UpdateAsync(order);
        }
    }
}
