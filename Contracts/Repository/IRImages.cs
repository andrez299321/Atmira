
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dto.Models;

namespace Contracts.Repository
{
    public interface IRImages :  IBaseRepository<Images>
    {
        Task<Images> GetByNameAsync(string Original);
    }
    
}
