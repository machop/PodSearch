using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PodSearch.Data.Abstract;
using PodSearch.Models;

namespace PodSearch
{
    [Route("api/[controller]")]
    public class PodcastController : ControllerBase
    {
        private IPodcastRepository _podcastRepository;

        public PodcastController(IPodcastRepository podcastRepository)
        {
            _podcastRepository = podcastRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _podcastRepository.GetSingle(e => e.Id == new Guid(id));
            if (response != null)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var response = _podcastRepository.GetAll();
            if (response != null)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpGet("search/{searchValue}")]
        public IActionResult Search(string searchValue)
        {
            var response = _podcastRepository.FindBy(e => e.Name.Contains(searchValue));
            if (response != null)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpPost]
        public Podcast Post(Podcast podcast)
        {
            var result = _podcastRepository.Add(podcast);
            _podcastRepository.Commit();
            return result.Entity;
        }
    }
}
