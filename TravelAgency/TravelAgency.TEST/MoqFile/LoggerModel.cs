using TravelAgency.BLL.BusinessModels;
using TravelAgency.DAL.Entities;

namespace TravelAgency.TEST.MoqFile
{
    public class LoggerModel
    {
        public static Logger GetLogger()
        {
            Logger logger = new Logger()
            {
                Id = 1,
                Level = "Fatal",
                Message = "TestMethod"
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
