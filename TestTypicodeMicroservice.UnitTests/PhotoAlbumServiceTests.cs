using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TypicodeMicroservice.Models;
using TypicodeMicroservice.Services;
using TypicodeMicroservice.Services.Interfaces;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestTypicodeMicroservice.UnitTests
{
    [TestClass]
    public class PhotoAlbumServiceTests
    {
        public PhotoAlbumServiceTests()
        {

            var photoAlbumProcessor = new Mock<IPhotoAlbumService>();
            IEnumerable<PhotoAlbumModel> photoAlbums = new List<PhotoAlbumModel>
            {
                new PhotoAlbumModel{ albumId = 1, photoId = 1,  photoThumbnailURL = "shabu",  photoURL = "photo", albumTitle = "SunPicture", photoTitle="sun set", userId=123 },
                new PhotoAlbumModel{ albumId = 1, photoId = 1,  photoThumbnailURL = "shabu",  photoURL = "photo", albumTitle = "SunPicture", photoTitle="sun rise", userId=124 },
                new PhotoAlbumModel{ albumId = 1, photoId = 1,  photoThumbnailURL = "shabu",  photoURL = "photo", albumTitle = "SunPicture", photoTitle="Dog bark", userId=125 },
                new PhotoAlbumModel{ albumId = 1, photoId = 1,  photoThumbnailURL = "shabu",  photoURL = "photo", albumTitle = "SunPicture", photoTitle="flower", userId=126 } };
            photoAlbumProcessor.Setup(t => t.GetPhotoAlbum())
                    .Returns(Task.FromResult(photoAlbums));

            this.PhotoAlbumProcessor = photoAlbumProcessor.Object;

        }
        public IAlbumService AlbumProcessor { get; }
        public IPhotoService PhotoProcessor { get; }
        public IPhotoAlbumService PhotoAlbumProcessor { get; }


        [TestMethod]
        public void GetPhotoAlbum_WhenCalled_ReturnPhotoAlbumModel()
        {
            Task<IEnumerable<PhotoAlbumModel>> photoalbums = this.PhotoAlbumProcessor.GetPhotoAlbum();
            Assert.AreEqual(4, photoalbums.Result.Count());
        }

        [TestMethod]
        public void GetPhotoAlbumByUserID_WhenCalled_ReturnPhotoAlbumModel()
        {
            int userid = 123;
            Task<IEnumerable<PhotoAlbumModel>> photoalbums = this.PhotoAlbumProcessor.GetPhotoAlbumByUserID(userid);
            Assert.AreEqual(1, photoalbums.Id);
        }
    }
}
