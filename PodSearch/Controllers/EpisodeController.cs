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
    public class EpisodeController : ControllerBase
    {
        private IEpisodeRepository _episodeRepository;

        public EpisodeController(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _episodeRepository.GetSingle(e => e.Id == new Guid(id));
            if (response != null)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpGet("search/{searchValue}")]
        public IActionResult Search(string searchValue)
        {
            var response = _episodeRepository.FindBy(e => e.EpisodeNumber.Equals(searchValue));
            if (response.Count() != 0)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpGet("getAllPodcastEpisodes/{podcastId}")]
        public IActionResult GetAllPodcastEpisodes(string podcastId)
        {
            var response = _episodeRepository.FindBy(e => e.PodcastId == new Guid(podcastId));
            if (response != null)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpPost]
        public Episode Post([FromBody]Episode episode)
        {
            var result = _episodeRepository.Add(episode);
            _episodeRepository.Commit();
            return result.Entity;
        }
    }
}
