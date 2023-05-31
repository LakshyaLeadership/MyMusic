using System.Collections.Generic;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyMusic.Api.Controllers;
using MyMusic.ApiContracts;
using MyMusic.Services;
using MyMusic.ViewModels;

namespace MyMusic.MsTest
{
    [TestClass]
    public class AlbumControllerMockUnitTest
    {
        AutofacServiceProvider autofacServiceProvider;
        public AlbumControllerMockUnitTest()
        {
            autofacServiceProvider = AutofacUnitTestSetup.InitAutofac();
        }

        [TestMethod]
        public void ValidAlbum_ShouldBe_ListedOut()
        {
            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            mockAlbumService.Setup(svc => svc.GetAlbumDetails(It.IsAny<long>())).Returns(GetTestAlbumDetails);
            AlbumController ctrl = new AlbumController(mockAlbumService.Object);
            GetAlbumDetailsResponse getAlbumDetailsResponse = ctrl.GetDetails(12);

            Assert.IsTrue(getAlbumDetailsResponse.Album.Songs.Count == 2, "Two songs in album");
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
