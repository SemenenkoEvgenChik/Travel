using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.TEST.MoqFile
{
    public static class AdminMoq
    {
        public static TourBLM GetTourBLL()
        {
            TourBLM tour = new TourBLM()
            {
                Id = 1,
                CountriesId = 1,
                Price = 333,
                FlightId = 1
            };
            return tour;
        }
        public static Tour GetTour()
        {
            Tour tour = new Tour()
            {
                Id = 1,
                CountriesId = 1,
                Price = 333,
                FlightId =1
            };
            return tour;
        }
        public static ManagerBLM GetManagerBLL()
        {
            ManagerBLM manager = new ManagerBLM()
            {
                Id = 1,
                Name = "Manager",
                UserId = "userId"
            };

            return manager;
        }
        public static Manager GetManager()
        {
            Manager manager = new Manager()
            {
                Id = 1,
                Name = "Manager",
                UserId= "userId"
            };

            return manager;
        }
        public static Customer GetCustomer()
        {
            Customer customer = new Customer()
            {
                Id=1,
                Name="Customer",
                UserId="userId"
            };

            return customer;
        }
        public static CustomerBLM GetCustomerBLL()
        {
            CustomerBLM customer = new CustomerBLM()
            {
                Id = 1,
                Name = "Customer",
                UserId = "userId"
            };

            return customer;
        }
        public static Logger GetLogger()
        {
            Logger logger = new Logger()
            {
                Id = 1,
                Level="Fatal",
                Message="TestMethod"
            };
            return logger;
        }

        public static LoggerBLM GetLoggerBLM()
        {
            LoggerBLM logger = new LoggerBLM()
            {
                Id = 1,
                Level = "Fatal",
                Message = "TestMethod"
            };
            return logger;
        }

    }
}
