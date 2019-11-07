namespace TravelAgency.BLL.BusinessModels
{
    public class ManagerBLM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserId { get; set; }

        public ManagerBLM(int id, string name, string surname, string userId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            UserId = userId;
        }
        public ManagerBLM()
        {
        }
    }
}
