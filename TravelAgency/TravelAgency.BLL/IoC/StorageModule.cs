using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Modules;
using System.Data.Entity;
using TravelAgency.BLL.Configs;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies;
using TravelAgency.DAL.Repositoies.Interfaces;
using TravelAgency.DAL.UnitOfWork;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.BLL.IoC
{
    public class StorageModule : NinjectModule
    {
        private string connectionString;
        public StorageModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<DbContext>().To<TravelAgencyContext>().WithConstructorArgument(connectionString);
            Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().WithConstructorArgument(arg => Kernel.Get<DbContext>());
            Bind<ApplicationUserManager>().ToSelf();

            Bind<ICityRepository>().To<CityRepository>();
            Bind<ICountriesRepository>().To<CountriesRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<ICustomerTourRepository>().To<TourCustomerRepository>();
            Bind<IFlightRepository>().To<FlightRepository>();
            Bind<IFoodRepository>().To<FoodRepository>();
            Bind<IManagerRepository>().To<ManagerRepository>();
            Bind<IMeansOfTransportRepository>().To<MeansOfTransportRepository>();
            Bind<IStatusClientRepository>().To<StatusClientRepository>();
            Bind<ITourRepository>().To<TourRepository>();
            Bind<ITripStatusRepository>().To<TripStatusRepository>();
            Bind<ITypeOfRestRepository>().To<TypeOfRestRepository>();
            Bind<ITypeOfTourRepository>().To<TypeOfTourRepository>();
            Bind<ILoggerRepository>().To<LoggerRepository>();

            Bind<IUnitOfWorks>().To<UnitOfWorks>();
        }
    }
}
