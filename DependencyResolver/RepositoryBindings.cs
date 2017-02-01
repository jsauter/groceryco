using GroceryCo.Repositories;
using GroceryCo.Repositories.Interfaces;
using Ninject.Modules;

namespace GroceryCo.DependencyResolver
{
    public class RepositoryBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductCatalogFileReader>().To<ProductCatalogFileReader>()
                .WithConstructorArgument("fileName", @"files\catalog.txt");
            Bind<IBasketFileReader>().To<BasketFileReader>()
                .WithConstructorArgument("fileName", @"files\basket.txt");

            Bind<IBasketRepository>().To<BasketRepository>();
            Bind<IProductCatalogRepository>().To<ProductCatalogRepository>();
        }
    }
}