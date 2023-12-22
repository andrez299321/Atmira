using Contracts.Infraestructure;
using Dto.Infraestructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class TvShowApi : ConsumeApi, ITvShowApi
    {
        private readonly string path = "shows";

        public TvShowApi(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<TvShowInfraestructure> GetByIdAsync(List<string> parameter)
        {
            return await GetAsync<TvShowInfraestructure>(path, parameter);
        }


        public async Task<List<TvShowInfraestructure>> GetAsync()
        {
            return await GetAsync<List<TvShowInfraestructure>>(path, null);
        }
    }
}
