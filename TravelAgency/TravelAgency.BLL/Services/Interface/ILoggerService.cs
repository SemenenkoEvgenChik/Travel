using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.BLL.BusinessModels;

namespace TravelAgency.BLL.Services.Interface
{
    public interface ILoggerService
    {
        Task<List<LoggerBLM>> GetLogger();

    }
}
