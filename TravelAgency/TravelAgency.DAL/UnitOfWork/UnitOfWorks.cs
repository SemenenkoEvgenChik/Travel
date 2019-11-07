using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Repositoies;
using TravelAgency.DAL.Repositoies.Interfaces;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.DAL.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly TravelAgencyContext _context;

        private ITypeOfTourRepository _typeOfTour;
        private ICityRepository _cities;
        private ICountriesRepository _countries;
        private ICustomerRepository _customers;
        private ICustomerTourRepository _customerTours;
        private IFlightRepository _flights;
        private IFoodRepository _foods;
        private IManagerRepository _managers;
        private IMeansOfTransportRepository _meansOfTransports;
        private IStatusClientRepository _statusClients;
        private ITourRepository _tours;
        private ITripStatusRepository _tripStatus;
        private ITypeOfRestRepository _typeOfRests;
        private IHotelRepository _hotelRepository;
        private ILoggerRepository _loggerRepository;

        public UnitOfWorks(TravelAgencyContext context)
        {
            _context = context;
        }
        public ILoggerRepository LoggerRepository
        {
            get
            {
                if (_loggerRepository == null)
                    _loggerRepository = new LoggerRepository(_context);

                return _loggerRepository;
            }
        }
        public IHotelRepository HotelRepository
        {
            get
            {
                if (_hotelRepository == null)
                    _hotelRepository = new HotelRepository(_context);

                return _hotelRepository;
            }
        }
      
        public ICityRepository CityRepository
        {
            get
            {
                if (_cities == null)
                    _cities = new CityRepository(_context);

                return _cities;
            }
        }
        public ICountriesRepository CountryRepository
        {
            get
            {
                if (_countries == null)
                    _countries = new CountriesRepository(_context);

                return _countries;
            }
        }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);

                return _customers;
            }
        }
        public ICustomerTourRepository TourCustomerRepository
        {
            get
            {
                if (_customerTours == null)
                    _customerTours = new TourCustomerRepository(_context);

                return _customerTours;
            }
        }
        public IFlightRepository FlightRepository
        {
            get
            {
                if (_flights == null)
                    _flights = new FlightRepository(_context);

                return _flights;
            }
        }
        public IFoodRepository FoodRepository
        {
            get
            {
                if (_foods == null)
                    _foods = new FoodRepository(_context);

                return _foods;
            }
        }
        public IManagerRepository ManagerRepository
        {
            get
            {
                if (_managers == null)
                    _managers = new ManagerRepository(_context);

                return _managers;
            }
        }
        public IMeansOfTransportRepository MeansOfTransportRepository
        {
            get
            {
                if (_meansOfTransports == null)
                    _meansOfTransports = new MeansOfTransportRepository(_context);

                return _meansOfTransports;
            }
        }
        public IStatusClientRepository StatusClientRepository
        {
            get
            {
                if (_statusClients == null)
                    _statusClients = new StatusClientRepository(_context);

                return _statusClients;
            }
        }
        public ITourRepository TourRepository
        {
            get
            {
                if (_tours == null)
                    _tours = new TourRepository(_context);

                return _tours;
            }
        }
        public ITripStatusRepository TripStatusRepository
        {
            get
            {
                if (_tripStatus == null)
                    _tripStatus = new TripStatusRepository(_context);

                return _tripStatus;
            }
        }
        public ITypeOfRestRepository TypeOfRestRepository
        {
            get
            {
                if (_typeOfRests == null)
                    _typeOfRests = new TypeOfRestRepository(_context);

                return _typeOfRests;
            }
        }
        
        public ITypeOfTourRepository TypeOfTourRepository
        {
            get
            {
                if (_typeOfTour == null)
                    _typeOfTour = new TypeOfTourRepository(_context);

                return _typeOfTour;
            }
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
