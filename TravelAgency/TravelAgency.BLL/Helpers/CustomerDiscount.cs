namespace TravelAgency.BLL.Helpers
{
    public static class CustomerDiscount
    {
        public static int DiscountCalculation(int stepDiscount, int limitDiscount, int countOrder)
        {
            int discount = 0;

            if (countOrder != 0 && limitDiscount != 0 && stepDiscount != 0)
            {
                discount = stepDiscount * countOrder;
                if (discount > limitDiscount)
                {
                    discount = limitDiscount;
                }
            }
            return discount;
        }
    }
}
