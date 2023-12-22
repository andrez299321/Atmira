using System;
using System.Collections.Generic;

namespace Dto.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Networks = new HashSet<Networks>();
            WebChannels = new HashSet<WebChannels>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Timezone { get; set; }

        public virtual ICollection<Networks> Networks { get; set; }
        public virtual ICollection<WebChannels> WebChannels { get; set; }
    }
}
