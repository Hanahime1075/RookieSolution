using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.DataAccessor
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
