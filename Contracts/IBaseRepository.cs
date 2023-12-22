using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBaseRepository <T>
    {
        Task<int> CreateAsync(T request);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T request, int id);
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
    }
}
