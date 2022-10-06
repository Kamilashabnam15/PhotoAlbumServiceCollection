using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypicodeMicroservice.Models;
using TypicodeMicroservice.Services.Interfaces;

namespace TypicodeMicroservice.Services
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        IAlbumService _albumService;
        IPhotoService _photoService;
        public PhotoAlbumService(IAlbumService albumService, IPhotoService photoService)
        {
            _albumService = albumService;
            _photoService = photoService;
        }
        public async Task<IEnumerable<PhotoAlbumModel>> GetPhotoAlbum()
        {

            var albummodel = await _albumService.GetAlbum();
            var photomodel = await _photoService.GetPhoto();

            var result = from album in albummodel
                         join photos in photomodel on album.id equals photos.albumId
                         select new PhotoAlbumModel()
                         {
                             userId = album.userId,
                             albumId = album.id,
                             albumTitle = album.title,
                             photoId = photos.id,
                             photoTitle = photos.title,
                             photoURL = photos.url,
                             photoThumbnailURL = photos.thumbnailUrl
                         };
            return result;
        }

        public async Task<IEnumerable<PhotoAlbumModel>> GetPhotoAlbumByUserID(int id)
        {

            var albummodel = await _albumService.GetAlbum();
            var photomodel = await _photoService.GetPhoto();

            var result = from album in albummodel
                         join photos in photomodel on album.id equals photos.albumId
                         where album.userId==id
                         select new PhotoAlbumModel()
                         {
                             userId = album.userId,
                             albumId = album.id,
                             albumTitle = album.title,
                             photoId = photos.id,
                             photoTitle = photos.title,
                             photoURL = photos.url,
                             photoThumbnailURL = photos.thumbnailUrl
                         };
            return result;



        }
    }
}

