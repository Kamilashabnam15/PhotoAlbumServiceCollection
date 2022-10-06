using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypicodeMicroservice.Models;

namespace TypicodeMicroservice.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumModel>> GetAlbum();
    }
}
