using Ninject.Modules;
using TravelAgency.BLL.Services;
using TravelAgency.BLL.Services.Interface;

namespace TravelAgency.WEB.IoC
{
    public class StorageServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerService>();
            Bind<ILoggerService>().To<LoggerService>();
            Bind<IManagerService>().To<ManagerService>();
            Bind<ITourService>().To<TourService>();
        }
    }
}