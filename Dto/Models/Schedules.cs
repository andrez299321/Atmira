using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class Schedules
    {
        public Schedules()
        {
            TvShows = new HashSet<TvShows>();
        }
        public int Id { get; set; }
        public string Time { get; set; }

        public virtual ICollection<TvShows> TvShows { get; set; }
    }
}
