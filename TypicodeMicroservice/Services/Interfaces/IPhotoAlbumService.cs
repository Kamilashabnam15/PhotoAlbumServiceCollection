using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypicodeMicroservice.Models;

namespace TypicodeMicroservice.Services
{
    public interface IPhotoAlbumService
    {
        Task<IEnumerable<PhotoAlbumModel>> GetPhotoAlbumByUserID(int id);
        Task<IEnumerable<PhotoAlbumModel>> GetPhotoAlbum();
    }
}
