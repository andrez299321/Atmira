using Dto.Infraestructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Controller
{
    public class TvShowQueryResponse
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Language { get; set; }
        public List<string> Genres { get; set; }
        public string? Status { get; set; }
        public int? Runtime { get; set; }
        public int? AverageRuntime { get; set; }
        public DateTime? premiered { get; set; }
        public DateTime? Ended { get; set; }
        public string? OfficialSite { get; set; }
        public double? AverageRating { get; set; }
        public string? NameNetwork { get; set; }
        public int? Weight { get; set; }
        public string? Summary { get; set; }
        public long? Updated { get; set; }
    }
    public class TvShowResponse
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Language { get; set; }
        public List<string> Genres { get; set; }
        public string? Status { get; set; }
        public int? Runtime { get; set; }
        public int? AverageRuntime { get; set; }
        public DateTime? premiered { get; set; }
        public DateTime? Ended { get; set; }
        public string? OfficialSite { get; set; }
        public ScheduleResponse? Schedule { get; set; }
        public RatingResponse? Rating { get; set; }
        public int? Weight { get; set; }
        public NetworkResponse? Network { get; set; }
        public WebChannelResponse? WebChannel { get; set; }
        public DvdCountryResponse? DvdCountry { get; set; }
        public ExternalsResponse? Externals { get; set; }
        public ImageResponse? Image { get; set; }
        public string? Summary { get; set; }
        public long? Updated { get; set; }
        public LinksResponse? Links { get; set; }
    }
    public class DvdCountryResponse
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Timezone { get; set; }
    }
    public class WebChannelResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CountryResponse? Country { get; set; }
        public string? OfficialSite { get; set; }
    }

    public class ScheduleResponse
    {
        public string? Time { get; set; }
        public List<string> Days { get; set; }
    }

    public class RatingResponse
    {
        public double? Average { get; set; }
    }

    public class NetworkResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CountryResponse? Country { get; set; }
        public string? OfficialSite { get; set; }
    }

    public class CountryResponse
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Timezone { get; set; }
    }

    public class ExternalsResponse
    {
        public int? Tvrage { get; set; }
        public int? Thetvdb { get; set; }
        public string? Imdb { get; set; }
    }

    public class ImageResponse
    {
        public string? Medium { get; set; }
        public string? Original { get; set; }
    }

    public class LinksResponse
    {
        public SelfResponse? Self { get; set; }
        public PreviousepisodeResponse? Previousepisode { get; set; }
    }

    public class SelfResponse
    {
        public string? Href { get; set; }
    }

    public class PreviousepisodeResponse
    {
        public string? Href { get; set; }
    }
}
