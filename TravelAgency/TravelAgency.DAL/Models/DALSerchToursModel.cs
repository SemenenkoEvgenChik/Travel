namespace TravelAgency.DAL.Models
{
    public class DALSerchToursModel
    {
        public int? NumberPerson { get; set; }
        public int? PriceDown { get; set; }
        public int? PriceUp { get; set; }
        public int? NumberOfStars { get; set; }
        public int? TypeOfRest { get; set; }

        public DALSerchToursModel()
        {
        }

        public DALSerchToursModel(int? numberPerson, int? priceDown, int? priceUp, int? numberOfStars, int? typeOfRest)
        {
            NumberPerson = numberPerson;
            PriceDown = priceDown;
            PriceUp = priceUp;
            NumberOfStars = numberOfStars;
            TypeOfRest = typeOfRest;
        }
    }
}
