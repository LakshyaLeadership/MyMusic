using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Services;

namespace MyMusic.Api.Controllers
{
    /// <summary>
    /// Http Status Code Response Style
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class Album2Controller : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public Album2Controller(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet]
        [Route("GetDetails/{albumId}")]
        public ActionResult<ViewModels.Album> GetDetails(long albumId)
        {
            return Ok(_albumService.GetAlbumDetails(albumId));
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("BuyAlbum")]
        public IActionResult BuyAlbum(long albumId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("BuySong")]
        public IActionResult BuySong(long songId)
        {
            return Ok();
        }

        public IActionResult PreviewAll(long albumId)
        {
            return Ok();
        }
    }
}