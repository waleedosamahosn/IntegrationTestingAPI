using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class ChangedPassResponseModel
    {
        public class ChangedPassResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public object data { get; set; }
        }
    }
}
