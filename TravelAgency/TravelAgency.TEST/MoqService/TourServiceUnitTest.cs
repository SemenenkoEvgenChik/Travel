using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels.RequestModel;
using TravelAgency.BLL.Services;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.Repositoies.Interfaces;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.TEST.MoqService
{
    [TestClass]
    public class TourServiceUnitTest
    {
        private Mock<IUnitOfWorks> _mockUnitOfWork;
        private Mock<ITourRepository> _mockTourRepository;

        [TestInitialize()]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWorks>();
            _mockTourRepository = new Mock<ITourRepository>();
        }

        [TestMethod]
        public async Task EditTour()
        {
            //Arrange
            int id = 1;
            Tour tour = MoqFile.TourModel.GetTour();
            List<Tour> tours = new List<Tour>();
            tours.Add(tour);
            _mockTourRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(tours.Where(t => t.Id == id).FirstOrDefault());

            _mockUnitOfWork.Setup(x => x.TourRepository).Returns(_mockTourRepository.Object);
            _mockUnitOfWork.Setup(s => s.Save());

            var service = new TourService(_mockUnitOfWork.Object);
            TourEditWithoutListOptionModel requesModel = new TourEditWithoutListOptionModel();
            requesModel.Price = 222;
            var act = await service.EditTour(requesModel);
            //Assert
            Assert.AreEqual(true, act);
        }
    }
}
