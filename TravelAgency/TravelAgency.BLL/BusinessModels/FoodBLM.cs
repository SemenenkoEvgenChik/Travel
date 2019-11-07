namespace TravelAgency.BLL.BusinessModels
{
    public class FoodBLM
    {
        public int Id { get; set; }
        public string TypeOfFood { get; set; }
        public FoodBLM(int id, string typeOfFood)
        {
            Id = id;
            TypeOfFood = typeOfFood;
        }
        public FoodBLM()
        {
        }

    }
}
