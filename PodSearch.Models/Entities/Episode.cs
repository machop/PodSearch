using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PodSearch.Models
{
    public class Episode : IEntityBase
    {
        public Episode()
        {
            
        }

        public Guid Id { get; set; }        
        public Guid PodcastId { get; set; }
        public DateTime DatePublished { get; set; }
        public string Url { get; set; }
        public string EpisodeNumber { get; set; }

        [ForeignKey(nameof(PodcastId))]
        public Podcast Podcast { get; set; }
        public ICollection<Transcription> Transcriptions { get; set; }
    }
}
