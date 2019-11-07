namespace TravelAgency.BLL.BusinessModels
{
    public class StatusClientBLM
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public StatusClientBLM(int id, string status)
        {
            Id = id;
            Status = status;
        }
        public StatusClientBLM()
        {
        }
    }
}
