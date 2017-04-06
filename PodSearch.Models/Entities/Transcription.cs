using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PodSearch.Models
{
    public class Transcription : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid EpisodeId { get; set; }
        public string TranscribedAudio { get; set; }
        public TimeSpan StartPosition { get; set; }
        public int Words { get; set; }

        [ForeignKey(nameof(EpisodeId))]
        public Episode Episode { get; set; }        
    }
}
