using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class Networks
    {
        public Networks()
        {
            TvShows = new HashSet<TvShows>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string OfficialSite { get; set; }
        public int? CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<TvShows> TvShows { get; set; }
    }
}
