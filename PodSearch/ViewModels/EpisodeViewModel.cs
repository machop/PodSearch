using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PodSearch.Models;

namespace PodSearch.ViewModels
{
    public class EpisodeViewModel
    {
        public Guid Id { get; set; }
        public Guid PodcastId { get; set; }
        public DateTime DatePublished { get; set; }
        public int EpisodeNumber { get; set; }
        public string Url { get; set; }
        public ICollection<Transcription> Transcriptions { get; set; }

    }
}
