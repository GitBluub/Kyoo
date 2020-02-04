﻿using Kyoo.Controllers;
using Kyoo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Kyoo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly ILibraryManager libraryManager;
        private readonly ITranscoder transcoder;
        private readonly string transmuxPath;

        public VideoController(ILibraryManager libraryManager, ITranscoder transcoder, IConfiguration config)
        {
            this.libraryManager = libraryManager;
            this.transcoder = transcoder;
            transmuxPath = config.GetValue<string>("transmuxTempPath");
        }

        [HttpGet("{showSlug}-s{seasonNumber}e{episodeNumber}")]
        public IActionResult Index(string showSlug, long seasonNumber, long episodeNumber)
        {
            WatchItem episode = libraryManager.GetWatchItem(showSlug, seasonNumber, episodeNumber);

            if (episode != null && System.IO.File.Exists(episode.Path))
                return PhysicalFile(episode.Path, "video/x-matroska", true);
            else
                return NotFound();
        }

        [HttpGet("transmux/{showSlug}-s{seasonNumber}e{episodeNumber}")]
        public async Task<IActionResult> Transmux(string showSlug, long seasonNumber, long episodeNumber)
        {
            WatchItem episode = libraryManager.GetWatchItem(showSlug, seasonNumber, episodeNumber);

            if (episode != null && System.IO.File.Exists(episode.Path))
            {
                string path = await transcoder.Transmux(episode);
                if (path != null)
                    return PhysicalFile(path, "application/x-mpegURL ", true);
                else
                    return StatusCode(500);
            }
            else
                return NotFound();
        }

        [HttpGet("transmux/{episodeLink}/segment/{chunk}")]
        public IActionResult GetTransmuxedChunk(string episodeLink, string chunk)
        {
            string path = Path.Combine(transmuxPath, episodeLink);
            path = Path.Combine(path, "segments" + Path.DirectorySeparatorChar + chunk);

            return PhysicalFile(path, "video/MP2T");
        }

        [HttpGet("transcode/{showSlug}-s{seasonNumber}e{episodeNumber}")]
        public async Task<IActionResult> Transcode(string showSlug, long seasonNumber, long episodeNumber)
        {
            WatchItem episode = libraryManager.GetWatchItem(showSlug, seasonNumber, episodeNumber);

            if (episode != null && System.IO.File.Exists(episode.Path))
            {
                string path = await transcoder.Transcode(episode);
                if (path != null)
                    return PhysicalFile(path, "application/x-mpegURL ", true);
                else
                    return StatusCode(500);
            }
            else
                return NotFound();
        }
    }
}