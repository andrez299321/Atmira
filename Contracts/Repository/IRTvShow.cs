
using System;
using System.Collections.Generic;
using System.Text;
using Dto.Controller;
using System.Threading.Tasks;
using Dto.Models;

namespace Contracts.Repository
{
    public interface IRTvShow:  IBaseRepository<TvShows>
    {
        Task<List<TvShowQueryResponse>> GetQueryAsync();
    }
    
}
