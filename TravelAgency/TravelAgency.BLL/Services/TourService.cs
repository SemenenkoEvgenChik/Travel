using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.BusinessModels.ResponseModel;
using TravelAgency.BLL.Mapping;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.BLL.Services
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWorks _db;
        public TourService(IUnitOfWorks db)
        {
            _db = db;
        }

        public async Task<bool> ChangeTypeOfTour(int IdTour, int TypeOfTour)
        {
            bool response = false;
            var tour = await _db.TourRepository.GetByIdAsync(IdTour);
            tour.TypeOfTourId = TypeOfTour;
            response = await _db.TourRepository.UpdateAsync(tour);

            return response;
        }
        public async Task<TourBLM> GiveTourInfoToBuyer(int tourId, string userId)
        {
            var customer = await _db.CustomerRepository.GetCustomerByIdentityUserId(userId);
            Tour tour = await _db.TourRepository.GetByIdAsync(tourId);
            bool check = await _db.TourCustomerRepository.CheckingAvailabilityTour(customer.Id, tourId);
            TourBLM tourBLL = MapTourModel.ToTourBLM(tour);
            if (check)
            {
                tourBLL.AlreadyOrdered = true;
            }
            else
            {
                tourBLL.AlreadyOrdered = false;
            }

            return tourBLL;
        }
        public async Task<ResponsePaginationTourModel> GetAllActiveTours(RequestPaginationToursModel model)
        {
            var requestModelDAL = MapPaginationModel.ToDALRequestPaginationTourModel(model);
            var tours = await _db.TourRepository.GetAllTours(requestModelDAL);
            var response = MapPaginationModel.ToResponsePaginationTourModel(tours);

            return response;
        }
        public async Task<ResponsePaginationTourModel> GetAllTours(RequestPaginationToursModel model)
        {
            var requestModelDAL = MapPaginationModel.ToDALRequestPaginationTourModel(model);
            var tours = await _db.TourRepository.GetAllTours(requestModelDAL);
            var response = MapPaginationModel.ToResponsePaginationTourModel(tours);

            return response;
        }
        public async Task<List<CityBLM>> GetCitisForCountry(int CountryId)
        {
            var cities = await _db.CityRepository.GetCitisForCountry(CountryId);
            List<CityBLM> response = MapCity.ToListCityModel(cities);

            return response;
        }
        public async Task<ListTourOpionsModel> GetListOptinModel()
        {
            var foods = await _db.FoodRepository.GetAllFoods();
            var flights = await _db.FlightRepository.GetAllFlight();
            var typeOfRests = await _db.TypeOfRestRepository.GetAllTypeOfRests();
            var typeOfTours = await _db.TypeOfTourRepository.GetAllTypeOfTours();
            var countries = await _db.CountryRepository.GetAllCountries();
            var cities = await _db.CityRepository.GetAllCities();
            var meanOfTransports = await _db.MeansOfTransportRepository.GetAllMeansOfTransports();
            var hotels = await _db.HotelRepository.GetAllHotelsAsync();
            var response = MapTourModel.ToListTourOpionsModel(foods, flights, typeOfRests, typeOfTours, countries, cities, meanOfTransports, hotels);

            return response;
        }
        public async Task AddTourAndFlight(CreateTourModel requesModel)
        {
            var flight = new Flight(requesModel.MeansOfTransportId, requesModel.WhereToId, requesModel.FromWhereId);
            var entityFlight = await _db.FlightRepository.CreateAsync(flight);
            var tour = MapTourModel.ToTour(requesModel, entityFlight.Id);
            await _db.TourRepository.CreateAsync(tour);
        }

        public async Task<TourBLM> GetTourById(int idTour)
        {
            var tour = await _db.TourRepository.GetByIdAsync(idTour);
            var tourBLM = MapTourModel.ToTourBLM(tour);
            return tourBLM;
        }
        public async Task<FlightBLM> GetFlightById(int idFlight)
        {
            var flight = await _db.FlightRepository.GetByIdAsync(idFlight);
            var flightBLM = MapFlight.ToFlightBLL(flight);

            return flightBLM;
        }

        public async Task EditTour(TourEditWithoutListOptionModel requesModel)
        {
            var tour = await _db.TourRepository.GetByIdAsync(requesModel.IdTour);
            var flight = await _db.FlightRepository.GetByIdAsync(requesModel.IdFlight);
            flight.FromWhereId = requesModel.FromWhereId;
            flight.WhereToId = requesModel.WhereToId;
            flight.MeansOfTransportId = requesModel.MeansOfTransportId;
            await _db.FlightRepository.UpdateAsync(flight);

            tour.ArrivalDate = requesModel.ArrivalDate;
            tour.DepartureDate = requesModel.DepartureDate;
            tour.FoodId = requesModel.FoodId;
            tour.CountriesId = requesModel.CountriesId;
            tour.Price = requesModel.Price;
            tour.MaxNumberOfPersons = requesModel.MaxNumberOfPersons;
            tour.TypeOfRestId = requesModel.TypeOfRestId;
            tour.TypeOfTourId = requesModel.TypeOfTourId;
            tour.HotelId = requesModel.HotelId;
            await _db.TourRepository.UpdateAsync(tour);
        }
    }
}
