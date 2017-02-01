using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryCo.DependencyResolver;
using GroceryCo.Interfaces;
using Ninject;
using Ninject.Modules;

namespace GroceryCo
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new Bindings());

            var modules = new List<INinjectModule>
            {
                new RepositoryBindings(),
                new ServiceBindings()
            };

            kernel.Load(modules);

            var selfCheckOut = kernel.Get<ISelfCheckout>();

            selfCheckOut.Run();
        }
    }
}
