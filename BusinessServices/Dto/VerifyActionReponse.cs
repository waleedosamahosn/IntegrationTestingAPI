using BusinessServices.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CategoryResponseViewModel;

namespace BusinessServices.Dto
{
    public class VerifyActionReponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } 
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public object Data {  get; set; }
        public string Url { get; set; }
    }
}
