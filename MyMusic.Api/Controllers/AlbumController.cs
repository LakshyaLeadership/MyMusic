using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMusic.ApiContracts;
using MyMusic.Services;
using MyMusic.ViewModels;

namespace MyMusic.Api.Controllers
{
    /// <summary>
    /// POCO Result Type return Style
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet]
        [Route("GetDetails/{albumId}")]
        public GetAlbumDetailsResponse GetDetails(long albumId)
        {
            GetAlbumDetailsResponse resp = new GetAlbumDetailsResponse();
            try
            {
                resp.Album = _albumService.GetAlbumDetails(albumId);
            }
            catch (Exception ex)
            {
                resp.Err(ex);
            }
            return resp;
        }

        [HttpPost]
        [Route("BuyAlbum")]
        public ApiResponse BuyAlbum(long albumId)
        {
            return ApiResponse.Success();
        }

        [HttpPost]
        [Route("BuySong")]
        public ApiResponse BuySong(long songId)
        {
            return ApiResponse.Success();
        }

        public ApiResponse PreviewAll(long albumId)
        {
            return ApiResponse.Success();
        }
    }
}
