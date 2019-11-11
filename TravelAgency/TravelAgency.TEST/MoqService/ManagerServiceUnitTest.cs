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
    public class ManagerServiceUnitTest
    {
        private Mock<IUnitOfWorks> _mockUnitOfWork;
        private Mock<IManagerRepository> _mockManagerRepository;

        [TestInitialize()]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWorks>();
            _mockManagerRepository = new Mock<IManagerRepository>();
        }

        [TestMethod]
        public async Task GetAllManagers_null()
        {
            List<Manager> managers = new List<Manager>();

            _mockManagerRepository.Setup(x => x.GetAllManagers()).ReturnsAsync(managers.ToList());
            _mockUnitOfWork.Setup(x => x.ManagerRepository).Returns(_mockManagerRepository.Object);

            var service = new ManagerService(_mockUnitOfWork.Object, null);
            List<ManagerBLM> act = await service.GetAllManagers();

            Assert.AreEqual(managers.Count(), act.Count());
        }

        [TestMethod]
        public async Task GetAllManagers_ListManagerViewModel()
        {
            Manager manager = MoqFile.ManagerModel.GetManager();
            List<Manager> managers = new List<Manager>();
            managers.Add(manager);

            _mockManagerRepository.Setup(x => x.GetAllManagers()).ReturnsAsync(managers.ToList());
            _mockUnitOfWork.Setup(x => x.ManagerRepository).Returns(_mockManagerRepository.Object);

            var service = new ManagerService(_mockUnitOfWork.Object, null);
            List<ManagerBLM> act = await service.GetAllManagers();

            Assert.AreEqual(managers.Count(), act.Count());
        }
    }
}
