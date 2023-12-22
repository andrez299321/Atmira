
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dto.Models;

namespace Contracts.Repository
{
    public interface IRSelves :  IBaseRepository<Selves>
    {
        Task<Selves> GetByNameAsync(string Href);
    }
    
}
