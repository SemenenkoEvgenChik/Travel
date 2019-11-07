using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.BLL.Mapping;
using TravelAgency.BLL.Services.Interface;
using TravelAgency.DAL.Entities;
using TravelAgency.DAL.UnitOfWork.Interface;

namespace TravelAgency.BLL.Services
{
    public class LoggerService:ILoggerService
    {
        private readonly IUnitOfWorks _db;
        public LoggerService(IUnitOfWorks db)
        {
            _db = db;
        }

        public async Task<List<LoggerBLM>> GetLogger()
        {
            List<Logger> loggers = await _db.LoggerRepository.GetLoggers();
            List<LoggerBLM> listLoggers = MapLogger.ToListLoggerBLM(loggers);
            return listLoggers;
        }


    }
}
