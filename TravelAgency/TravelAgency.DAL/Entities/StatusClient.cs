namespace TravelAgency.DAL.Entities
{
    public class StatusClient : BaseEntity
    {
        public StatusClient(int id, string status):base(id)
        {
            Id = id;
            Status = status;
        }
        public StatusClient()
        {
        }
        public string Status { get; set; }

    }
}
