namespace TravelAgency.DAL.Entities
{
    public class TourCustomer : BaseEntity
    {
        public int CustomerId { get; set; }
        public int TourId { get; set; }
        public int TripStatusId { get; set; }
        public int NumberPerson { get; set; }
        public int Discount { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual TripStatus TripStatus { get; set; }

    }
}
