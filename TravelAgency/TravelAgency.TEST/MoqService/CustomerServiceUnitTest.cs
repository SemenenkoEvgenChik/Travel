using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.Services;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.TEST.MoqService
{
    [TestClass]
    public class CustomerServiceUnitTest
    {
        private Mock<IUnitOfWorks> _mockUnitOfWork;
        private Mock<ICustomerRepository> _mockCustomerRepository;

        [TestInitialize()]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWorks>();
            _mockCustomerRepository = new Mock<ICustomerRepository>();
        }

        [TestMethod]
        public async Task GetCustomer_Customer()
        {
            string userId = "userId";
            Customer customer = MoqFile.CustomerModel.GetCustomer();
            List<Customer> customers = new List<Customer>();
            customers.Add(customer);

            _mockCustomerRepository.Setup(x => x.GetCustomerByIdentityUserId(userId)).Callback(() => { customers.Where(ui => ui.UserId == userId).FirstOrDefault(); });
            _mockUnitOfWork.Setup(x => x.CustomerRepository).Returns(_mockCustomerRepository.Object);
            var service = new CustomerService(_mockUnitOfWork.Object, null);
            CustomerBLM result = await service.SearchCustomerByEmail(userId);

            Assert.AreEqual(customer.UserId, result.UserId);
        }
    }
}
