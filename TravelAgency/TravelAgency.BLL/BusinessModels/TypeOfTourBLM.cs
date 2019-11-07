namespace TravelAgency.BLL.BusinessModels
{
    public class TypeOfTourBLM
    {
        public TypeOfTourBLM(int id, string description)
        {
            Id = id;
            Description = description;
        }
        public TypeOfTourBLM()
        {
        }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
