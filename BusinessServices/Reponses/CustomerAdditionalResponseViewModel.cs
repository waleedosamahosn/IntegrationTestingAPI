using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class CustomerAdditionalResponseViewModel
    {
        public class DataFieldCustomerAdditionalResponse
        {
            public string id { get; set; }
            public string type { get; set; }
            public string validationType { get; set; }
            public List<string> source { get; set; }
            public string value { get; set; }
            public string name { get; set; }
            public string englishName { get; set; }
            public double order { get; set; }
            public bool isDisabled { get; set; }
            public List<OptionFieldFieldCustomerAdditionalResponse> options { get; set; }
        }

        public class OptionFieldFieldCustomerAdditionalResponse
        {
            public string caption { get; set; }
            public string key { get; set; }
        }

        public class RootCustomerAdditionalResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public List<DataFieldCustomerAdditionalResponse> data { get; set; }
        }
    }
}
