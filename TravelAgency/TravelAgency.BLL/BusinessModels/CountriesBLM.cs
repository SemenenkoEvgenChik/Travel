namespace TravelAgency.BLL.BusinessModels
{
    public class CountriesBLM
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string NameOfCountry { get; set; }

        public CountriesBLM(int id, string key, string nameOfCountry)
        {
            Id = id;
            Key = key;
            NameOfCountry = nameOfCountry;
        }
        public CountriesBLM()
        {
        }
    }
}
