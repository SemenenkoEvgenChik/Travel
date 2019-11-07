namespace TravelAgency.BLL.BusinessModels
{
    public class TripStatusBLM
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public TripStatusBLM()
        {
        }

        public TripStatusBLM(int id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
