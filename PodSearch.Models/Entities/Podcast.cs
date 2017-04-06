using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodSearch.Models
{
    public class Podcast : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public ICollection<Episode> Episodes { get; set; }
    }
}
