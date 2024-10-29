using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.Register_LoginResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class RegisterService : IRegisterService
    {
        public class RequestModelRegister
        {
            public string mobile { get; set; }
            public string pin { get; set; }
            public string fcmToken { get; set; }
        }

        public async Task<VerifyActionReponse> RgisterData(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();


            using (var client = new HttpClient())
            {

                var RespobseData = new RequestModelRegister
                {
                    mobile = "+201751379920",
                    pin = "147258",
                    fcmToken = ""
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(RespobseData),
                        Encoding.UTF8, "application/json");

                var response = client.PostAsync(requestDto.BaseUrl +"/"+requestDto.Url, c).Result;

                string responseAsString = await response.Content.ReadAsStringAsync();
                var responseCategory = JsonConvert.DeserializeObject<RootAuthenticationViewModel>(responseAsString);

                if (responseCategory != null && responseCategory.code == 
                    (int) ResponseStatusEnum.Error)
                {
                    verifyActionReponse.IsSuccess = true;

                    verifyActionReponse.Name = "Register";
                    verifyActionReponse.Data = responseCategory;

                    if (responseCategory.data == null)
                    {
                        verifyActionReponse.Message = "Success with empty data";
                    }

                    else
                    {
                        verifyActionReponse.Message = "Success";
                    }
                    return verifyActionReponse;
                }

                return verifyActionReponse;

            }

        }
    }
}
