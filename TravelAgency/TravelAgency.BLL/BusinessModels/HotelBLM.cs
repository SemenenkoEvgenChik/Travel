namespace TravelAgency.BLL.BusinessModels
{
    public class HotelBLM
    {
        public int Id { get; set; }
        public int NumberOfStars { get; set; }

        public HotelBLM(int id, int numberOfStars)
        {
            Id = id;
            NumberOfStars = numberOfStars;
        }
    }
}
