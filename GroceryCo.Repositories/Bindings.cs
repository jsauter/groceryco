using System.IO;
using System.Runtime.InteropServices;
using GroceryCo.Repositories.Interfaces;
using Ninject.Modules;

namespace GroceryCo.Repositories
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductCatalogFileReader>().To<ProductCatalogFileReader>();
            Bind<IBasketFileReader>().To<BasketFileReader>();

            Bind<IBasketRepository>().To<BasketRepository>();
            Bind<IProductCatalogRepository>().To<IProductCatalogRepository>();
        }
    }
}