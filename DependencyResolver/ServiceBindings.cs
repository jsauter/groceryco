using GroceryCo.Services;
using GroceryCo.Services.Interfaces;
using Ninject.Modules;

namespace GroceryCo.DependencyResolver
{
    public class ServiceBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IPriceService>().To<PriceService>();
            Bind<IBasketService>().To<BasketService>();            
        }
    }
}