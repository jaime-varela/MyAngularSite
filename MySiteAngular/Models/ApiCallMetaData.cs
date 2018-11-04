using System.Collections.Generic;

namespace MySiteAngular.Models
{
    public class ApiCallMetaData
    {
        public string Category {get; set;}
        public string Name {get; set;}
        public List<string> ParamNames {get; set;}
        public string Description {get; set;}
        public string EndPoint {get; set;}
    }
}