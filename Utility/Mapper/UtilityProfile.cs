using AutoMapper;
using Dto.Controller;
using Dto.Global;
using Dto.Infraestructure;
using Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Utility.Mapper
{
    public class UtilityProfile : Profile
    {
        public UtilityProfile() {
            CreateMap<TvShowResponse, TvShowInfraestructure>().ReverseMap();

            CreateMap<ScheduleResponse, ScheduleInfraestructure>().ReverseMap();
            CreateMap<RatingResponse, RatingInfraestructure>().ReverseMap();
            CreateMap<NetworkResponse, NetworkInfraestructure>().ReverseMap();

            CreateMap<WebChannelResponse, WebChannelInfraestructure>().ReverseMap();
            CreateMap<DvdCountryResponse, DvdCountryInfraestructure>().ReverseMap();
            CreateMap<ExternalsResponse, ExternalsInfraestructure>().ReverseMap();

            CreateMap<ImageResponse, ImageInfraestructure>().ReverseMap();
            CreateMap<LinksResponse, LinksInfraestructure>().ReverseMap();
            CreateMap<CountryResponse, CountryInfraestructure>().ReverseMap();
            
            CreateMap<SelfResponse, SelfInfraestructure>().ReverseMap();
            CreateMap<PreviousepisodeResponse, PreviousepisodeInfraestructure>().ReverseMap();







            CreateMap<TvShowInfraestructure, TvShows>()
                    .ForMember(dest => dest.Links, opt => opt.Ignore())
                    .ForMember(dest => dest.Ratings, opt => opt.Ignore())
                    .ForMember(dest => dest.Externals, opt => opt.Ignore())
                    .ForMember(dest => dest.Schedules, opt => opt.Ignore())
                    .ForMember(dest => dest.Network, opt => opt.Ignore())
                    .ForMember(dest => dest.Images, opt => opt.Ignore());


            CreateMap<ScheduleInfraestructure, Schedules>().ReverseMap();
            CreateMap<RatingInfraestructure, Ratings>().ReverseMap();
            CreateMap<NetworkInfraestructure, Networks>().ReverseMap();

            CreateMap<WebChannelInfraestructure, WebChannels>().ReverseMap();
            CreateMap<DvdCountryInfraestructure, DvdCountries>().ReverseMap();
            CreateMap<ExternalsInfraestructure, Externals>().ReverseMap();

            CreateMap<ImageInfraestructure, Images>().ReverseMap();
            CreateMap<LinksInfraestructure, Links>().ReverseMap();
            CreateMap<CountryInfraestructure, Countries>().ReverseMap();

            CreateMap<SelfInfraestructure, Selves>().ReverseMap();
            CreateMap<PreviousepisodeInfraestructure, Previousepisodes>().ReverseMap();

        }
    }
}
