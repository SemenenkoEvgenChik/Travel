using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.UnitOfWork.Interface
{
    public interface IUnitOfWorks : IDisposable
    {
        ITypeOfTourRepository TypeOfTourRepository { get; }
        ICityRepository CityRepository { get; }
        ICountriesRepository CountryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICustomerTourRepository TourCustomerRepository { get; }
        IFlightRepository FlightRepository { get; }
        IFoodRepository FoodRepository { get; }
        IManagerRepository ManagerRepository { get; }
        IMeansOfTransportRepository MeansOfTransportRepository { get; }
        IStatusClientRepository StatusClientRepository { get; }
        ITourRepository TourRepository { get; }
        ITripStatusRepository TripStatusRepository { get; }
        ITypeOfRestRepository TypeOfRestRepository { get; }
        IHotelRepository HotelRepository { get; }
        ILoggerRepository LoggerRepository { get;}
        void Save();
    }
}
