using System;
using System.Collections.Generic;
using System.Text;
using PodSearch.Models;

namespace PodSearch.Data
{
    class PodSearchDbInitializer
    {
        private static PodSearchContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (PodSearchContext)serviceProvider.GetService(typeof(PodSearchContext));

            //InitializeSchedules();
        }
    }
}
