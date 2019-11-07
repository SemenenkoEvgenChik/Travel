using System;

namespace TravelAgency.BLL.FilterModel
{
    public class AppException : Exception
    {
        public AppException()
        {

        }
        public AppException(string message) : base(message)
        {

        }
    }
}
