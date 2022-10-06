using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypicodeMicroservice.Services;
using TypicodeMicroservice.Services.Interfaces;

namespace TypicodeMicroservice
{
    public static class ContainerConfig
    {
        public static IContainer configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PhotoAlbumService>().As<IPhotoAlbumService>();
            builder.RegisterType<PhotoService>().As<IPhotoService>();
            builder.RegisterType<AlbumService>().As<IAlbumService>(); //To Do we can optimize it by registering it as assembly
            return builder.Build();
        }
    }
}
