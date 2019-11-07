namespace TravelAgency.BLL.BusinessModels
{
    public class MeansOfTransportBLM
    {
        public int Id { get; set; }
        public string TypeOfTransport { get; set; }
        public MeansOfTransportBLM(int id, string typeOfTransport)
        {
            Id = id;
            TypeOfTransport = typeOfTransport;
        }
        public MeansOfTransportBLM()
        {
        }
    }
}
