using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class Links
    {
        public Links()
        {
            Previousepisodes = new HashSet<Previousepisodes>();
            Selves = new HashSet<Selves>();
            TvShows = new HashSet<TvShows>();
        }


        public int Id { get; set; }
        public string SelfHref { get; set; }
        public string PreviousepisodeHref { get; set; }

        public virtual ICollection<TvShows> TvShows { get; set; }
        public virtual ICollection<Previousepisodes> Previousepisodes { get; set; }
        public virtual ICollection<Selves> Selves { get; set; }
    }
}
