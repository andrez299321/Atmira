using Contracts.Business;
using Dto.Controller;
using Dto.Global;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Atmira.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class TvShowsController : ControllerBase
    {

        private readonly ITvShowBusiness _tvShowBusiness;

        public TvShowsController(ITvShowBusiness tvShowBusiness)
        {
            _tvShowBusiness = tvShowBusiness;
        }


        [HttpGet]
        [Route("GetList")]
        public Task<BaseResponse<TvShowResponse>> GetListAsync()
        {
            return _tvShowBusiness.GetListTvShowResponseAsync();
        }

        [HttpGet]
        [Route("GetQueryDatabase")]
        public Task<BaseResponse<TvShowQueryResponse>> GetQueryAsync()
        {
            return _tvShowBusiness.GetListTvShowQueryResponseAsync();
        }

        [HttpGet]
        [Route("GetListById")]
        public Task<BaseResponse<TvShowResponse>> GetListByIdAsync(int id)
        {
            return _tvShowBusiness.GetListTvShowByIdResponseAsync(id);
        }

        [HttpPost]
        [Route("Sincronize")]
        public Task<BaseResponse<TvShowResponse>> SincronizeAsync()
        {
            return _tvShowBusiness.GetSincronizeAsync();
        }
    }
}
