using System;
using System.Collections.Generic;
using System.Text;
using PodSearch.Data.Abstract;
using PodSearch.Models;

namespace PodSearch.Data.Repositories
{
    public class TranscriptionRepository : EntityBaseRepository<Transcription>, ITranscriptionRepository
    {
        public TranscriptionRepository(PodSearchContext context)
            : base(context)
        { }

    }
}
