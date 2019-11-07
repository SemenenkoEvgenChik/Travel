using System.Collections.Generic;
using System.Linq;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.BusinessModels.Pagination;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Enums;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Enums;
using TravelAgency.DAL.Models;

namespace TravelAgency.BLL.Mapping
{
    public static class MapPaginationModel
    {
        public static DALRequestPaginationTourModel ToDALRequestPaginationTourModel(this RequestPaginationToursModel model)
        {
            SortIndex sortIndex = (SortIndex)model.sortIndex;
            StatusTour statusTour = (StatusTour)model.statusTour;
            DALSerchToursModel DALSerchTours = MapSerchTourModel.ToDALSerchToursModel(model.SerchTours);
            var response = new DALRequestPaginationTourModel(model.NumberPage, model.SizePage, statusTour, sortIndex, DALSerchTours);
            return response;
        }

        public static DALRequestPaginationCustomersModel ToDALRequestPaginationCustomersModel(this RequestPaginationCustomersModel model)
        {
            return new DALRequestPaginationCustomersModel(model.NumberPage, model.SizePage);
        }

        public static ResponsePaginationTourModel ToResponsePaginationTourModel(this DALResponsePaginationTourModel<Tour> response)
        {
            SortIndexBLL sortIndex = (SortIndexBLL)response.SortIndex;
            var tour = response.Data;
            var listTourBLL = tour.Select(x => MapTourModel.ToTourBLM(x)).ToList();
            SerchToursModel serchTours = MapSerchTourModel.ToSerchToursModel(response.DALSerchTours);
            return new ResponsePaginationTourModel(response.PageNumber,response.PageSize,response.TotalItems,response.TotalPages, listTourBLL, sortIndex, serchTours);
        }
        public static ResponsePaginationCustomersModel ToResponsePaginationCustomerModel(this DALResponsePaginationCustomersModel<Customer> response)
        {
            var customers = response.Data;
            List<CustomerBLM> listCustomerBLL = customers.Select(x => MapCustomer.ToCustomerBLM(x)).ToList();
            return new ResponsePaginationCustomersModel(response.PageNumber, response.PageSize, response.TotalItems, response.TotalPages, listCustomerBLL);
        }
    }
}
