using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapFood
    {
        public static FoodBLM ToFoodBLL(Food food)
        {
            return new FoodBLM(food.Id,food.TypeOfFood);
        }
    }
}
