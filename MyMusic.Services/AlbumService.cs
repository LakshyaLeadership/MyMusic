using System;
using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MyMusic.EFCoreDbFirst;
using MyMusic.Repositories;

namespace MyMusic.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> _albumRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AlbumService(IRepository<Album> albumRepository, IMapper mapper, ILogger<AlbumService> logger)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public ViewModels.Album GetAlbumDetails(long albumId)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            DateTime now = DateTime.UtcNow;

            _logger.LogInformation($"{nameof(GetAlbumDetails)} started");

            Album entity = _albumRepository.GetById(albumId);
            ViewModels.Album vm = _mapper.Map<ViewModels.Album>(entity);

            sw.Stop();

            var elapsedSeconds = (DateTime.UtcNow - now).TotalMilliseconds;

            _logger.LogInformation($"{nameof(GetAlbumDetails)} ends. Took {elapsedSeconds} seconds");
            return vm;
        }
    }
}
