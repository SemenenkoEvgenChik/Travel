using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelAgency.DAL.Entities
{
    public class Manager : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public Manager()
        {
        }
        public Manager(string name, string surname, string userId)
        {
            Name = name;
            Surname = surname;
            UserId = userId;
        }
    }
}
