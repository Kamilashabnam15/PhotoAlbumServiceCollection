using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TypicodeMicroservice.Models;
using TypicodeMicroservice.Services.Interfaces;

namespace TypicodeMicroservice.Services
{
    public class AlbumService : IAlbumService
    {
        public async Task<IEnumerable<AlbumModel>> GetAlbum()
        {
            using (var httpClient = new HttpClient())
            {
                var albummodel = JsonConvert.DeserializeObject<List<AlbumModel>>(
                            await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/albums")
                        );
                return albummodel;
            }
        }
    }
}
