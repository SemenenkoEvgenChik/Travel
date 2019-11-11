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
    public class LoggerServiceUnitTest
    {
        private Mock<IUnitOfWorks> _mockUnitOfWork;

        private Mock<ILoggerRepository> _mockLoggerRepository;

        [TestInitialize()]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWorks>();
            _mockLoggerRepository = new Mock<ILoggerRepository>();
        }

        [TestMethod]
        public async Task GetLogger_LoggerViewModel()
        {
            Logger logger = MoqFile.LoggerModel.GetLogger();
            List<Logger> loggers = new List<Logger>();
            loggers.Add(logger);

            _mockLoggerRepository.Setup(x => x.GetLoggers()).ReturnsAsync(loggers.ToList());
            _mockUnitOfWork.Setup(x => x.LoggerRepository).Returns(_mockLoggerRepository.Object);

            var service = new LoggerService(_mockUnitOfWork.Object);
            List<LoggerBLM> listLoggers = await service.GetLogger();

            Assert.AreEqual(loggers.Count(), listLoggers.Count());
        }
        [TestMethod]
        public async Task GetLogger_Null()
        {
            List<Logger> loggers = new List<Logger>();

            _mockLoggerRepository.Setup(x => x.GetLoggers()).ReturnsAsync(loggers.ToList());
            _mockUnitOfWork.Setup(x => x.LoggerRepository).Returns(_mockLoggerRepository.Object);

            var service = new LoggerService(_mockUnitOfWork.Object);
            List<LoggerBLM> listLoggers = await service.GetLogger();

            Assert.AreEqual(loggers.Count(), listLoggers.Count());
        }
    }
}
