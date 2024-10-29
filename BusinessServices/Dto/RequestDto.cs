using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Dto
{
    public class RequestDto
    {
        public string Url { get; set; }

        public string BaseUrl { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }


    }
}
