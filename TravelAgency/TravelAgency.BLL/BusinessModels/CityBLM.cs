namespace TravelAgency.BLL.BusinessModels
{
    public class CityBLM
    {
        public int Id { get; set; }
        public string KeyCountry { get; set; }
        public string NameOfCity { get; set; }

        public CityBLM(int id, string keyCountry, string nameOfCity)
        {
            Id = id;
            KeyCountry = keyCountry;
            NameOfCity = nameOfCity;
        }
        public CityBLM()
        {
        }
    }
}
