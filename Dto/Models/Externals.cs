using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class Externals
    {
        public Externals()
        {
            TvShows = new HashSet<TvShows>();
        }
        public int Id { get; set; }
        public int? Tvrage { get; set; }
        public int? Thetvdb { get; set; }
        public string Imdb { get; set; }

        public virtual ICollection<TvShows> TvShows { get; set; }
    }
}
