
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dto.Models;

namespace Contracts.Repository
{
    public interface IRExternals :  IBaseRepository<Externals>
    {
        Task<Externals> GetByNameAsync(Externals ext);
    }
    
}
