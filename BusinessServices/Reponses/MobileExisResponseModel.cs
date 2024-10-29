using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class MobileExisResponseModel
    {
        public class MobileExisResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public bool data { get; set; }
        }

    }
}
