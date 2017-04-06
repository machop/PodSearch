using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PodSearch.Models;

namespace PodSearch.ViewModels
{
    public class TranscriptionViewModel
    {
        public Guid Id { get; set; }
        public Guid EpisodeId { get; set; }
        public string TranscribedAudio { get; set; }
        public TimeSpan StartPosition { get; set; }
        public int Words { get; set; }
    }
}
