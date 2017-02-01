using GroceryCo.Interfaces;
using Ninject.Modules;

namespace GroceryCo
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ISelfCheckout>().To<SelfCheckout>();
        }
    }
}