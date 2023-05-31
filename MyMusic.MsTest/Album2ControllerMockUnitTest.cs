using System.Collections.Generic;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyMusic.Api.Controllers;
using MyMusic.Services;
using MyMusic.ViewModels;

namespace MyMusic.MsTest
{
    [TestClass]
    public class Album2ControllerMockUnitTest
    {

        AutofacServiceProvider autofacServiceProvider;
        public Album2ControllerMockUnitTest()
        {
            autofacServiceProvider = AutofacUnitTestSetup.InitAutofac();
        }

        [TestMethod]
        public void ValidAlbum_ShouldBe_ListedOut()
        {
            const int TestAlbumId = 12;

            Mock<IAlbumService> mockAlbumService = new Mock<IAlbumService>();
            mockAlbumService.Setup(svc => svc.GetAlbumDetails(TestAlbumId)).Returns(GetTestAlbumDetails);

            Album2Controller ctrl = new Album2Controller(mockAlbumService.Object);
            ActionResult<Album> getAlbumDetailsResponse = ctrl.GetDetails(TestAlbumId);
            
            mockAlbumService.Verify(svc => svc.GetAlbumDetails(TestAlbumId), Times.Once);

            Assert.IsInstanceOfType(getAlbumDetailsResponse.Result, typeof(OkObjectResult));
            OkObjectResult okObjectResult = getAlbumDetailsResponse.Result as OkObjectResult;

            Assert.IsNotNull(okObjectResult);
            Album response = okObjectResult.Value as Album;
            

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Songs.Count == 2, "albumResponse.Value.Songs.Count == 2");
        }

        public Album GetTestAlbumDetails()
        {
            return new Album()
            {
                Artist = new Artist(),

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
