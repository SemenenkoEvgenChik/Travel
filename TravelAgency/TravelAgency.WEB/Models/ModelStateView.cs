using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.WEB.Models
{
    public class ModelStateView
    {
        public bool StateResult { get; set; }
        public List<Error> Error { get; set; }
        public ModelStateView()
        {
        }
        public ModelStateView(bool stateResult, List<Error> error)
        {
            this.StateResult = stateResult;
            this.Error = error;
        }
    }
    public class Error
    {
        public string Key { get; set; }
        public List<string> Errors { get; set; }
    }
}