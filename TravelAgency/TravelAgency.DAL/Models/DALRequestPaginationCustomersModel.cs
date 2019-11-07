using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DAL.Models
{
    public class DALRequestPaginationCustomersModel
    {
        public int NumberPage { get; set; }
        public int SizePage { get; set; }

        public DALRequestPaginationCustomersModel()
        {
        }
        public DALRequestPaginationCustomersModel(int numberPage, int sizePage)
        {
            NumberPage = numberPage;
            SizePage = sizePage;
        }
    }
}
