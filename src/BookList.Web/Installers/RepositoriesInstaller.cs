using BookList.Core.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using BookList.Core.Repositories.Memory;

namespace BookList.Web.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<MemoryDataSource>()
                .Instance(new MemoryDataGenerator().Generate())
                .LifestyleSingleton());

            container.Register(Component.For<IBookRepository>().ImplementedBy<MemoryBookRepository>());
            container.Register(Component.For<IAuthorRepository>().ImplementedBy<MemoryAuthorRepository>());
        }
    }
}