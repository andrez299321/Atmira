using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Infraestructure
{
    public class TvShowInfraestructure
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
        public ScheduleInfraestructure? Schedule { get; set; }
        public RatingInfraestructure? Rating { get; set; }
        public int? Weight { get; set; }
        public NetworkInfraestructure? Network { get; set; }
        public WebChannelInfraestructure? WebChannel { get; set; }
        public DvdCountryInfraestructure? DvdCountry { get; set; }
        public ExternalsInfraestructure? Externals { get; set; }
        public ImageInfraestructure? Image { get; set; }
        public string? Summary { get; set; }
        public long? Updated { get; set; }
        public LinksInfraestructure? Links { get; set; }
    }
    public class DvdCountryInfraestructure
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Timezone { get; set; }
    }
    public class WebChannelInfraestructure
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public CountryInfraestructure? Country { get; set; }
        public string? OfficialSite { get; set; }
    }

    public class ScheduleInfraestructure
    {
        public string? Time { get; set; }
        public List<string> Days { get; set; }
    }

    public class RatingInfraestructure
    {
        public double? Average { get; set; }
    }

    public class NetworkInfraestructure
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CountryInfraestructure? Country { get; set; }
        public string? OfficialSite { get; set; }
    }

    public class CountryInfraestructure
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Timezone { get; set; }
    }

    public class ExternalsInfraestructure
    {
        public int? Tvrage { get; set; }
        public int? Thetvdb { get; set; }
        public string? Imdb { get; set; }
    }

    public class ImageInfraestructure
    {
        public string? Medium { get; set; }
        public string? Original { get; set; }
    }

    public class LinksInfraestructure
    {
        public SelfInfraestructure? Self { get; set; }
        public PreviousepisodeInfraestructure? Previousepisode { get; set; }
    }

    public class SelfInfraestructure
    {
        public string? Href { get; set; }
    }

    public class PreviousepisodeInfraestructure
    {
        public string? Href { get; set; }
    }
}
