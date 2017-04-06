using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PodSearch.Models;

namespace PodSearch.ViewModels
{
    public class PodcastViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ICollection<Episode> Episodes { get; set; }

    }
}
