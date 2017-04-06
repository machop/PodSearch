using System;
using System.Collections.Generic;
using System.Text;

namespace PodSearch.Models
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }
}
