using System;
using System.Collections.Generic;
using System.Text;
using PodSearch.Data.Abstract;
using PodSearch.Models;

namespace PodSearch.Data.Repositories
{
    public class PodcastRepository : EntityBaseRepository<Podcast>, IPodcastRepository
    {
        public PodcastRepository(PodSearchContext context)
            : base(context)
        { }

    }
}
