using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class CustomerIdNumberResponseViewModel
    {
        public class DataCustomerIdNumberResponse
        {
            public string idNumber { get; set; }
        }

        public class RootCustomerIdNumberResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public DataCustomerIdNumberResponse data { get; set; }
        }

    }
}
