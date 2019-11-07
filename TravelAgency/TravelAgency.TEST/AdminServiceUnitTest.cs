using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TravelAgency.DAL.Repositoies.Interfaces;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.TEST
{
    [TestClass]
    public class AdminServiceUnitTest
    {
        private Mock<IUnitOfWorks> _mockUnitOfWork;

        private Mock<ILoggerRepository> _mockLoggerRepository;
        private Mock<ICustomerRepository> _mockCustomerRepository;
        private Mock<IManagerRepository> _mockManagerRepository;
        private Mock<ITourRepository> _mockTourRepository;

        [TestInitialize()]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWorks>();
            _mockLoggerRepository = new Mock<ILoggerRepository>();
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockManagerRepository = new Mock<IManagerRepository>();
            _mockTourRepository = new Mock<ITourRepository>();
        }

        //[TestMethod]
        //public async Task EditTour()
        //{
        //    //Arrange
        //    int id = 1;
        //    Tour tour = MoqFile.AdminMoq.GetTour();
        //    List<Tour> tours = new List<Tour>();
        //    tours.Add(tour);
        //    _mockTourRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(tours.Where(t => t.Id == id).FirstOrDefault());
            
        //    _mockUnitOfWork.Setup(x => x.TourRepository).Returns(_mockTourRepository.Object);
        //    _mockUnitOfWork.Setup(s => s.Save());

        //    var service = new AdminService(_mockUnitOfWork.Object, null);
        //    TourEditWithoutListOptionViewModel requesModel = new TourEditWithoutListOptionViewModel();
        //    requesModel.Price = 222;
        //    var act = service.EditTour(requesModel);
        //    //Assert
        //        Assert.AreEqual(tour.Price, requesModel.Price);
        //}

        //[TestMethod]
        //public async Task GetAllManagers_null()
        //{
        //    List<Manager> managers = new List<Manager>();

        //    _mockManagerRepository.Setup(x => x.GetAllManagers()).ReturnsAsync(managers.ToList());
        //    _mockUnitOfWork.Setup(x => x.ManagerRepository).Returns(_mockManagerRepository.Object);

        //    var service = new AdminService(_mockUnitOfWork.Object, null);
        //    ListManagerViewModel act = await service.GetAllManagers();

        //    Assert.AreEqual(managers.Count(), act.Managers.Count());
        //}

        //[TestMethod]
        //public async Task GetAllManagers_ListManagerViewModel()
        //{
        //    Manager manager = MoqFile.AdminMoq.GetManager();
        //    List<Manager> managers = new List<Manager>();
        //    managers.Add(manager);

        //    _mockManagerRepository.Setup(x => x.GetAllManagers()).ReturnsAsync(managers.ToList());
        //    _mockUnitOfWork.Setup(x => x.ManagerRepository).Returns(_mockManagerRepository.Object);

        //    var service = new AdminService(_mockUnitOfWork.Object, null);
        //    ListManagerViewModel act = await service.GetAllManagers();

        //    Assert.AreEqual(managers.Count(), act.Managers.Count());
        //}

        //[TestMethod]
        //public async Task GetCustomer_Customer()
        //{
        //    string userId = "userId";
        //    Customer customer = MoqFile.AdminMoq.GetCustomer();
        //    List<Customer> customers = new List<Customer>();
        //    customers.Add(customer);

        //    _mockCustomerRepository.Setup(x => x.GetCustomerByIdentityUserId(userId)).Callback(() => { customers.Where(ui => ui.UserId == userId).FirstOrDefault();});
        //    _mockUnitOfWork.Setup(x => x.CustomerRepository).Returns(_mockCustomerRepository.Object);
        //    var service = new AdminService(_mockUnitOfWork.Object, null);
        //    CustomerBLL result = await service.SearchCustomerByEmail(userId);

        //    Assert.AreEqual(customer.UserId, result.UserId);
        //}

        //    [TestMethod]
        //    public async Task GetLogger_LoggerViewModel()
        //    {
        //        Logger logger = MoqFile.AdminMoq.GetLogger();
        //        List<Logger> loggers = new List<Logger>();
        //        loggers.Add(logger);

        //        _mockLoggerRepository.Setup(x => x.GetLoggers()).ReturnsAsync(loggers.ToList());
        //        _mockUnitOfWork.Setup(x => x.LoggerRepository).Returns(_mockLoggerRepository.Object);

        //        var service = new AdminService(_mockUnitOfWork.Object, null);
        //        LoggerViewModel loggerViewModel = await service.GetLogger();

        //        Assert.AreEqual(loggers.Count(), loggerViewModel.ListLoggerBLM.Count());
        //    }
        //    [TestMethod]
        //    public async Task GetLogger_Null()
        //    {
        //        List<Logger> loggers = new List<Logger>();

        //        _mockLoggerRepository.Setup(x => x.GetLoggers()).ReturnsAsync(loggers.ToList());
        //        _mockUnitOfWork.Setup(x => x.LoggerRepository).Returns(_mockLoggerRepository.Object);

        //        var service = new AdminService(_mockUnitOfWork.Object, null);
        //        LoggerViewModel loggerViewModel = await service.GetLogger();

        //        Assert.AreEqual(loggers.Count(), loggerViewModel.ListLoggerBLM.Count());
        //    }
    }
}
