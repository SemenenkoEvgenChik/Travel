using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL.Enums;

namespace TravelAgency.DAL.Models
{
    public class DALResponsePaginationTourModel<TModel> where TModel : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
        public SortIndex  SortIndex {get;set;}
        public IEnumerable<TModel> Data { get; set; }
        public DALSerchToursModel DALSerchTours { get; set; }
    }
}
