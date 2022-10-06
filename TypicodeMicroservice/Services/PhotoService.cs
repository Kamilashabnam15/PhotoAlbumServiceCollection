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
    public class PhotoService : IPhotoService
    {
        public async Task<IEnumerable<PhotoModel>> GetPhoto()
        {
            using (var httpClient = new HttpClient())
            {
                var photoModel = JsonConvert.DeserializeObject<List<PhotoModel>>(
                            await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/photos")
                        );
                return photoModel;
            }
        }
    }
}
