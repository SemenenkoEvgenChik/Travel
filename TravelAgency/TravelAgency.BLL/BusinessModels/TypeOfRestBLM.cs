using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL.BusinessModels
{
    public class TypeOfRestBLM
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public TypeOfRestBLM(int id, string description)
        {
            Id = id;
            Description = description;
        }
        public TypeOfRestBLM()
        {
        }
    }
}
