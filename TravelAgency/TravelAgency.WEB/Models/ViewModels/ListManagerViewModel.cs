using System.Collections.Generic;
using TravelAgency.BLL.BusinessModels;

namespace TravelAgency.WEB.Models.ViewModels
{
    public class ListManagerViewModel
    {
        public IEnumerable<ManagerBLM> Managers { get; set; }
        public ListManagerViewModel()
        {
        }
        public ListManagerViewModel(IEnumerable<ManagerBLM> managers)
        {
            Managers = managers;
        }
    }
}