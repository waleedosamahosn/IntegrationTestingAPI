using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class RefreshResponseModel
    {
        public class DataRefreshResponse
        {
            public int id { get; set; }
            public string name { get; set; }
            public object username { get; set; }
            public string jwtToken { get; set; }
            public string refreshToken { get; set; }
            public object userDetails { get; set; }
        }

        public class RootRefreshResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public DataRefreshResponse data { get; set; }
        }
    }
}
