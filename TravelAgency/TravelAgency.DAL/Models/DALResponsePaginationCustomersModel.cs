using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DAL.Models
{
    public class DALResponsePaginationCustomersModel<TModel> where TModel : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
        public IEnumerable<TModel> Data { get; set; }
    }
}
