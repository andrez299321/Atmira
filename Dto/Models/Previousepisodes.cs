using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class Previousepisodes
    {
        public int Id { get; set; }
        public string Href { get; set; }
        public int? LinksId { get; set; }

        public virtual Links Links { get; set; }
    }
}
