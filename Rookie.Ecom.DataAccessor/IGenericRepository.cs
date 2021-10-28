﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(object id);

        Task<T> GetByAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");

        List<T> GetAll();
        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(object id);
    }
}
