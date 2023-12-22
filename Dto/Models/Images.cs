using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class Images
    {
        public Images()
        {
            TvShows = new HashSet<TvShows>();
        }
        public int Id { get; set; }
        public string Medium { get; set; }
        public string Original { get; set; }

        public virtual ICollection<TvShows> TvShows { get; set; }
    }
}
