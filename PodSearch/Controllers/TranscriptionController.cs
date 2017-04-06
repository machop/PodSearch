using System;
using Microsoft.AspNetCore.Mvc;
using PodSearch.Data.Abstract;
using PodSearch.Models;

namespace PodSearch
{
    [Route("api/[controller]")]
    public class TranscriptionController : ControllerBase
    {
        private ITranscriptionRepository _transcriptionRepository;

        public TranscriptionController(ITranscriptionRepository transcriptionRepository)
        {
            _transcriptionRepository = transcriptionRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _transcriptionRepository.GetSingle(e => e.Id == new Guid(id));
            if (response != null)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpGet("getAllEpisodeTranscriptions/{episodeId}")]
        public IActionResult GetAllEpisodeTranscriptions(string episodeId)
        {
            var response = _transcriptionRepository.FindBy(e => e.EpisodeId == new Guid(episodeId));
            if (response != null)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpGet("search/{searchValue}")]
        public IActionResult Search(string searchValue)
        {
            var response = _transcriptionRepository.FindBy(e => e.TranscribedAudio.Contains(searchValue));
            if (response != null)
            {
                return new OkObjectResult(response);
            }
            return NotFound();
        }

        [HttpPost]
        public Transcription Post([FromBody]Transcription transcription)
        {
            var result = _transcriptionRepository.Add(transcription);
            _transcriptionRepository.Commit();
            return result.Entity;
        }
    }
}
