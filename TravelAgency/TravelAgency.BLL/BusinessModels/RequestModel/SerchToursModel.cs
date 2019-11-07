namespace TravelAgency.BLL.BusinessModels.RequestModel
{
    public class SerchToursModel
    {
        public int? NumberPerson { get; set; }
        public int? PriceDown { get; set; }
        public int? PriceUp { get; set; }
        public int? NumberOfStars { get; set; }
        public int? TypeOfRest { get; set; }

        public SerchToursModel(int? numberPerson, int? priceDown, int? priceUp, int? numberOfStars, int? typeOfRest)
        {
            NumberPerson = numberPerson;
            PriceDown = priceDown;
            PriceUp = priceUp;
            NumberOfStars = numberOfStars;
            TypeOfRest = typeOfRest;
        }
        public SerchToursModel()
        {
                
        }
    }
}
