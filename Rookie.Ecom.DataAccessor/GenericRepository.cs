using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.DataAccessor.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcomDbContext _dbContext;

        public GenericRepository(EcomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
