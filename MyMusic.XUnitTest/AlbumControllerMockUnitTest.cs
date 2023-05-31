using System.Collections.Generic;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyMusic.Api.Controllers;
using MyMusic.Services;
using MyMusic.ViewModels;
using Xunit;

namespace MyMusic.XUnitTest
{
    
    public class AlbumControllerMockUnitTest
    {
        AutofacServiceProvider _autofacServiceProvider;
        public AlbumControllerMockUnitTest()
        {
            _autofacServiceProvider = AutofacUnitTestSetup.InitAutofac();
        }

        [Fact]
        public void ValidAlbum_ShouldBe_ListedOut()
        {
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            mockAlbumService.Setup(svc => svc.GetAlbumDetails(It.IsAny<int>())).Returns(GetTestAlbumDetails);
            AlbumController ctrl = new AlbumController(mockAlbumService.Object);
            var getAlbumDetailsResponse = ctrl.GetDetails(12);

            Assert.True(getAlbumDetailsResponse.Album.Songs.Count == 2, "Two songs in album");
        }

        public Album GetTestAlbumDetails()
        {
            return new Album()
            {
                Artist = new Artist() { },

                Songs = new List<Song>()
                {
                    new Song()
                    {
                        AlbumId = 1001,
                        Name = "Don't go breaking my heart",
                    },
                    new Song()
                    {
                        AlbumId = 1001,
                        Name = "Nobody Else",
                    }
                }
            };
        }
    }
}
