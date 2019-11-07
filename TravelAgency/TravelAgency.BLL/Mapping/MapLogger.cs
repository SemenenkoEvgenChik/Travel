using System.Collections.Generic;
using System.Linq;
using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.BLL.Mapping
{
    public static class MapLogger
    {
        public static LoggerBLM ToLoggerBLM(Logger logger)
        {
            return new LoggerBLM(logger.Id, logger.Message,logger.MessageTemplate, logger.Level, logger.TimeStamp, logger.Exception, logger.Properties);
        }
        public static List<LoggerBLM> ToListLoggerBLM(this List<Logger> loggers)
        {
            List<LoggerBLM> response = loggers.Select(l => ToLoggerBLM(l)).ToList();
            return response;
        }
    }
}
