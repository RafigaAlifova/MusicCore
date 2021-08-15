using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;

namespace Business.IoC.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfMusicDal>().As<IMusicDal>();
            builder.RegisterType<EfGenreDal>().As<IGenreDal>();
            builder.RegisterType<EfSingerDal>().As<ISingerDal>();

            builder.RegisterType<MusicManager>().As<IMusicService>();
            builder.RegisterType<GenreManager>().As<IGenreService>();
            builder.RegisterType<SingerManager>().As<ISingerService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
