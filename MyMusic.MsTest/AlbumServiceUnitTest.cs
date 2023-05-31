using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMusic.Services;
using MyMusic.ViewModels;

namespace MyMusic.MsTest
{
    [TestClass]
    public class AlbumServiceUnitTest
    {
        AutofacServiceProvider autofacServiceProvider;
        public AlbumServiceUnitTest()
        {
            autofacServiceProvider = AutofacUnitTestSetup.InitAutofac();
        }

        [TestMethod]
        public void ValidAlbum_ShouldBe_ListedOut()
        {
            AlbumService albumService = autofacServiceProvider.GetRequiredService(typeof(IAlbumService)) as AlbumService;
            Assert.IsNotNull(albumService, "Auto-fac albumService != null");
            Album getAlbumDetails =  albumService.GetAlbumDetails(12);
            Assert.IsNotNull(getAlbumDetails.Songs,"getAlbumDetails.Songs != null");
            Assert.IsTrue(getAlbumDetails.Songs.Count == 6);
        }
    }
}
