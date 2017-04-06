using PodSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodSearch.Data.Abstract
{
    public interface IPodcastRepository : IEntityBaseRepository<Podcast> { }

    public interface IEpisodeRepository : IEntityBaseRepository<Episode> { }

    public interface ITranscriptionRepository : IEntityBaseRepository<Transcription> { }
}
