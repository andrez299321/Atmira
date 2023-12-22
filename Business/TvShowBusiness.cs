using AutoMapper;
using AutoMapper.Internal;
using Contracts.Business;
using Contracts.Infraestructure;
using Contracts.Repository;
using Dto.Controller;
using Dto.Global;
using Dto.Infraestructure;
using Dto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{

    public class TvShowBusiness : ITvShowBusiness
    {
        private readonly ITvShowApi _tvShowApi;


        private readonly IRTvShow _rTvShow;
        private readonly IRSelves _rSelves;
        private readonly IRSchedules _rSchedules;
        private readonly IRRatings _rRatings;
        private readonly IRLinks _rLinks;
        private readonly IRImages _rImages;
        private readonly IRNetworks _rNetworks;
        private readonly IRExternals _rExternals;
        private readonly IRCountries _rCountries;


        private readonly IMapper _mapper;

        public TvShowBusiness(ITvShowApi tvShowApi, IRTvShow rTvShow,
            IRSelves rSelves, IRSchedules rSchedules,
            IRRatings rRatings, IRLinks rLinks,
            IRImages rImages, IRNetworks rNetworks,
            IRExternals rExternals, IRCountries rCountries, IMapper mapper)
        {
            _tvShowApi = tvShowApi;
            _rTvShow = rTvShow;
            _rSelves = rSelves;
            _rSchedules = rSchedules;
            _rRatings = rRatings;
            _rLinks = rLinks;
            _rImages = rImages;
            _rNetworks = rNetworks;
            _rExternals = rExternals;
            _rCountries = rCountries;
            _mapper = mapper;
        }

        public async Task<BaseResponse<TvShowResponse>> GetSincronizeAsync()
        {
            var data = await _tvShowApi.GetAsync();
            BaseResponse<TvShowResponse> obj = null;

            if (data != null && data.Count > 0)
            {
                
                

                foreach (var item in data)
                {
                    var tvshowdb = _mapper.Map<TvShows>(item);
                    var linksdb = _mapper.Map<Links>(item.Links);
                    if (linksdb != null)
                    {
                        await _rLinks.CreateAsync(linksdb);
                        var link = await _rLinks.GetByNameAsync(linksdb.SelfHref);
                        tvshowdb.LinksId = link.Id;
                    }
                    

                    var ratingsdb = _mapper.Map<Ratings>(item.Rating);
                    if (ratingsdb != null)
                    {
                        await _rRatings.CreateAsync(ratingsdb);
                        var rat = await _rRatings.GetByNameAsync(ratingsdb.Average);
                        tvshowdb.RatingsId = rat.Id;
                    }
                    var schedulesdb = _mapper.Map<Schedules>(item.Schedule);
                    if (schedulesdb != null)
                    {
                        await _rSchedules.CreateAsync(schedulesdb);
                        var sch = await _rSchedules.GetByNameAsync(schedulesdb.Time);
                        tvshowdb.ScheduleId = sch.Id;
                    }
                    var externalsdb = _mapper.Map<Externals>(item.Externals);
                    if (externalsdb != null)
                    {
                        await _rExternals.CreateAsync(externalsdb);
                        var ext = await _rExternals.GetByNameAsync(externalsdb);
                        tvshowdb.ExternalId = ext.Id;
                    }

                    

                    var networkdb = _mapper.Map<Networks>(item.Network);
                    if (networkdb != null)
                    {
                        var countriesdb = _mapper.Map<Countries>(item.Network.Country);
                        if (countriesdb != null)
                        {
                            await _rCountries.CreateAsync(countriesdb);
                            var country = await _rCountries.GetByNameAsync(countriesdb.Name);
                            networkdb.CountryId = country.Id;
                        }
                        await _rNetworks.CreateAsync(networkdb);
                        var net = await _rNetworks.GetByNameAsync(networkdb.Name);
                        tvshowdb.NetworkId = net.Id;
                    }

                    
                    if (tvshowdb != null)
                    {
                        
                        await _rTvShow.CreateAsync(tvshowdb);
                    }
                }
                obj = new BaseResponse<TvShowResponse>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = null
                };
            }
            else
            {
                obj = new BaseResponse<TvShowResponse>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No existe informacion",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<TvShowResponse>> GetListTvShowByIdResponseAsync(int id)
        {
            List<string> list = new List<string>();
            list.Add(id.ToString());
            var data = await _tvShowApi.GetByIdAsync(list);
            List<TvShowInfraestructure> listData = new List<TvShowInfraestructure>();
            listData.Add(data);
            BaseResponse<TvShowResponse> obj = null;

            List<TvShowResponse> resultData = new List<TvShowResponse>();
            resultData = _mapper.Map<List<TvShowInfraestructure>, List<TvShowResponse>>(listData);

            if (listData != null && listData.Count > 0)
            {
                obj = new BaseResponse<TvShowResponse>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = resultData
                };
            }
            else
            {
                obj = new BaseResponse<TvShowResponse>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No existe informacion",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<TvShowResponse>> GetListTvShowResponseAsync()
        {
            var data = await _tvShowApi.GetAsync();
            BaseResponse<TvShowResponse> obj = null;

            List<TvShowResponse> resultData = new List<TvShowResponse>();
            resultData = _mapper.Map<List<TvShowInfraestructure>, List<TvShowResponse>>(data);

            if (data != null && data.Count > 0)
            {
                obj = new BaseResponse<TvShowResponse>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = resultData
                };
            }
            else
            {
                obj = new BaseResponse<TvShowResponse>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No existe informacion",
                    Response = null
                };
            }
            return obj;
        }

        public async Task<BaseResponse<TvShowQueryResponse>> GetListTvShowQueryResponseAsync()
        {
            BaseResponse<TvShowQueryResponse> obj = null;
            var data = await _rTvShow.GetQueryAsync();
            
            if (data != null && data.Count > 0)
            {
                obj = new BaseResponse<TvShowQueryResponse>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = data
                };
            }
            else
            {
                obj = new BaseResponse<TvShowQueryResponse>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No existe informacion",
                    Response = null
                };
            }
            return obj;
        }
        public async Task<BaseResponse<TvShowResponse>> SincronizeData()
        {
            var data = await _tvShowApi.GetAsync();


            BaseResponse<TvShowResponse> obj = null;

            List<TvShowResponse> resultData = new List<TvShowResponse>();
            resultData = _mapper.Map<List<TvShowInfraestructure>, List<TvShowResponse>>(data);

            if (data != null && data.Count > 0)
            {
                obj = new BaseResponse<TvShowResponse>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = resultData
                };
            }
            else
            {
                obj = new BaseResponse<TvShowResponse>()
                {
                    CodigoDeError = 99,
                    Mensaje = "No existe informacion",
                    Response = null
                };
            }
            return obj;
        }
    }
}
