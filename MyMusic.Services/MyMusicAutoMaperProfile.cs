using AutoMapper;
using MyMusic.EFCoreDbFirst;

namespace MyMusic.Services
{
    public class MyMusicAutoMaperProfile : Profile
    {
        public MyMusicAutoMaperProfile()
        {
            CreateMap<Artist, ViewModels.Artist>();

            CreateMap<Song, ViewModels.Song>();

            CreateMap<Album, ViewModels.Album>()
                .ForMember(e => e.Artist, opt => opt.MapFrom(x => x.Artist))
                .ForMember(e => e.Songs, opt => opt.MapFrom(x => x.Song));

        }
    }
}