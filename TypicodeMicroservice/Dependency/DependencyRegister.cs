using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypicodeMicroservice.Services;
using TypicodeMicroservice.Services.Interfaces;

namespace TypicodeMicroservice.Dependency
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PhotoAlbumService>().As<IPhotoAlbumService>().InstancePerLifetimeScope();
            builder.RegisterType<PhotoService>().As<IPhotoService>().InstancePerLifetimeScope();
            builder.RegisterType<AlbumService>().As<IAlbumService>().InstancePerLifetimeScope();

        }
    }
}
