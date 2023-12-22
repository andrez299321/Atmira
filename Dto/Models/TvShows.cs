using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class TvShows
    {
        public TvShows()
        {
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Status { get; set; }
        public int? Runtime { get; set; }
        public int? AverageRuntime { get; set; }
        public DateTime? Premiered { get; set; }
        public DateTime? Ended { get; set; }
        public string OfficialSite { get; set; }
        public int? Weight { get; set; }
        public string Summary { get; set; }
        public long? Updated { get; set; }
        public int? NetworkId { get; set; }
        public int? ExternalId { get; set; }
        public int? ImagesId { get; set; }
        public int? LinksId { get; set; }
        public int? RatingsId { get; set; }
        public int? ScheduleId { get; set; }

        public virtual Networks Network { get; set; }

        public virtual Externals Externals { get; set; }
        public virtual Images Images { get; set; }
        public virtual Links Links { get; set; }
        public virtual Ratings Ratings { get; set; }
        public virtual Schedules Schedules { get; set; }

    }
}
