using Autoconnect.Data.Infrastructure;
using LC_02.Data.Infrastructure;
using LC_02.Services.Students;
using SimpleInjector;

namespace LC_02.Services.Infrastucture
{
    public static class SimpleInjectorInitializer
    {
        public static void InitializeContainer(Container container, Lifestyle lifeStyle)
        {
            //database
            container.Register<IDatabaseFactory, DatabaseFactory>(lifeStyle);
            container.Register<IUnitOfWork, UnitOfWork>(lifeStyle);

            //register generic repository
            container.Register(typeof(IRepository<>), typeof(Repository<>), lifeStyle);
            //services
            container.Register<IStudentService, StudentService>(lifeStyle);
            
        }
    }
}
