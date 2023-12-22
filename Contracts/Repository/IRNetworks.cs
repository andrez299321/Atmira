
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dto.Models;

namespace Contracts.Repository
{
    public interface IRNetworks :  IBaseRepository<Networks>
    {
        Task<Networks> GetByNameAsync(string name);
    }
    
}
