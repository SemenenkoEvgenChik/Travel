using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Web.Mvc;
using TravelAgency.BLL.IoC;

namespace TravelAgency.WEB.IoC
{
    public static class RegistratorDependencies
    {
        private static IKernel Kernel { get; set; }

        public static void RegisterDependencies()
        {
            var kernel = CreateKernel();
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public static IKernel CreateKernel()
        {
            if (Kernel == null)
            {
                NinjectModule storageModule = new StorageModule("DefaultConnection");
                NinjectModule storageServiceModule = new StorageServiceModule();
                Kernel = new StandardKernel(storageModule, storageServiceModule);
            }
            return Kernel;
        }
    }
}