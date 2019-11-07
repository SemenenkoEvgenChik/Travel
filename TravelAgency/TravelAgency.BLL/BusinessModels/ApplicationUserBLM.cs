namespace TravelAgency.BLL.BusinessModels
{
    public class ApplicationUserBLM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public ApplicationUserBLM(string id, string email)
        {
            Id = id;
            Email = email;
        }
        public ApplicationUserBLM()
        {
        }
    }
}
