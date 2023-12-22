
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dto.Models;

namespace Contracts.Repository
{
    public interface IRLinks :  IBaseRepository<Links>
    {
        Task<Links> GetByNameAsync(string SelfHref);
    }
    
}
