using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class Ratings
    {
        public Ratings()
        {
            TvShows = new HashSet<TvShows>();
        }
        public int Id { get; set; }
        public double? Average { get; set; }


        public virtual ICollection<TvShows> TvShows { get; set; }
    }
}
