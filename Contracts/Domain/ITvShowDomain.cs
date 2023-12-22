using Dto.Controller;
using Dto.Global;
using System.Threading.Tasks;

namespace Contracts.Business
{
    public interface ITvShowBusiness
    {
        Task<BaseResponse<TvShowResponse>> GetListTvShowResponseAsync();
        Task<BaseResponse<TvShowResponse>> GetListTvShowByIdResponseAsync(int id);
        Task<BaseResponse<TvShowResponse>> GetSincronizeAsync();
        Task<BaseResponse<TvShowQueryResponse>> GetListTvShowQueryResponseAsync();
    }
}
