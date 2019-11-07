using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelAgency.DAL.EF;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Enums;
using TravelAgency.DAL.Models;
using TravelAgency.DAL.Repositoies.Interfaces;

namespace TravelAgency.DAL.Repositoies
{
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        public TourRepository(TravelAgencyContext context) : base(context)
        {
        }


        public async Task<DALResponsePaginationTourModel<Tour>> GetAllTours(DALRequestPaginationTourModel model)
        {
            Expression<Func<Tour, bool>> stateTour = null;
            if (model.StatusTour == StatusTour.newTour)
            {
                stateTour = t => t.DepartureDate >= DateTime.Now;
            }
            if (model.StatusTour == StatusTour.activeTour)
            {
                stateTour = t => t.DepartureDate < DateTime.Now && t.ArrivalDate >= DateTime.Now;
            }
            if (model.StatusTour == StatusTour.completedTour)
            {
                stateTour = t => t.ArrivalDate <= DateTime.Now;
            }

            Expression<Func<Tour, int>> sort = s => s.TypeOfTour.Id;
            if (model.SortIndex == SortIndex.Количество_человек)
            {
                sort = s => s.MaxNumberOfPersons;
            }
            if (model.SortIndex == SortIndex.Количество_звезд_гостиницы)
            {
                sort = s => s.Hotel.Id;
            }
            if (model.SortIndex == SortIndex.Тип_поездки)
            {
                sort = s => s.TypeOfRest.Id;
            }
            if (model.SortIndex == SortIndex.Цена)
            {
                sort = s => s.Price;
            }
            int pageSize = model.SizePage;
            int page = model.NumberPage;
            int totalItems = await _context.Tours.Where(stateTour).Where(x =>
               ((model.DALSerchToursModel.NumberOfStars == null) || x.HotelId == model.DALSerchToursModel.NumberOfStars) &&
               ((model.DALSerchToursModel.NumberPerson == null) || x.MaxNumberOfPersons <= model.DALSerchToursModel.NumberPerson) &&
               ((model.DALSerchToursModel.PriceDown == null) || x.Price >= model.DALSerchToursModel.PriceDown) &&
               ((model.DALSerchToursModel.PriceUp == null) || x.Price <= model.DALSerchToursModel.PriceUp) &&
               ((model.DALSerchToursModel.TypeOfRest == null) || x.TypeOfRestId == model.DALSerchToursModel.TypeOfRest)
            ).CountAsync();

            IEnumerable<Tour> tours = await _context.Tours
                .Where(stateTour)
                .Where(x =>
               ((model.DALSerchToursModel.NumberOfStars == null) || x.HotelId == model.DALSerchToursModel.NumberOfStars) &&
               ((model.DALSerchToursModel.NumberPerson == null) || x.MaxNumberOfPersons <= model.DALSerchToursModel.NumberPerson) &&
               ((model.DALSerchToursModel.PriceDown == null) || x.Price >= model.DALSerchToursModel.PriceDown) &&
               ((model.DALSerchToursModel.PriceUp == null) || x.Price <= model.DALSerchToursModel.PriceUp) &&
               ((model.DALSerchToursModel.TypeOfRest == null) || x.TypeOfRestId == model.DALSerchToursModel.TypeOfRest)
            )
                .OrderBy(sort)
                .Skip((page - 1) * model.SizePage)
                .Take(pageSize).ToListAsync();

            DALResponsePaginationTourModel<Tour> response = new DALResponsePaginationTourModel<Tour>
            {
                PageNumber = page,
                TotalItems = totalItems,
                PageSize = pageSize,
                Data = tours,
                SortIndex = model.SortIndex,
                DALSerchTours = model.DALSerchToursModel
            };
            return response;
        }
    }
}
