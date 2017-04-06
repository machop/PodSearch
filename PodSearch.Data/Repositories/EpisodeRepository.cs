using System;
using System.Collections.Generic;
using System.Text;
using PodSearch.Data.Abstract;
using PodSearch.Models;

namespace PodSearch.Data.Repositories
{
    public class EpisodeRepository : EntityBaseRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(PodSearchContext context)
            : base(context)
        { }

    }
}
