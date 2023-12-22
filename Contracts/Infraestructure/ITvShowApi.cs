using Dto.Infraestructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Infraestructure
{
    public interface ITvShowApi
    {
        Task<List<TvShowInfraestructure>> GetAsync();
        Task<TvShowInfraestructure> GetByIdAsync(List<string> parameter);
    }
}
