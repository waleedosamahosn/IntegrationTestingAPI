using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class Register_LoginResponseViewModel
    {
        public class DataViewModel
        {
            public int id { get; set; }
            public object name { get; set; }
            public object username { get; set; }
            public string jwtToken { get; set; }
            public string refreshToken { get; set; }
            public TableViewModel userDetails { get; set; }
        }

        public class RootAuthenticationViewModel
        {
            public int code { get; set; }
            public string message { get; set; }
            public DataViewModel data { get; set; }
        }

        public class TableViewModel
        {
            public int userId { get; set; }
            public object name { get; set; }
            public string mobile { get; set; }
            public object email { get; set; }
            public object address { get; set; }
            public object dateOfBirth { get; set; }
            public object imageUrl { get; set; }
            public object gender { get; set; }
            public int unReadNotificationCount { get; set; }
        }
    }
}
