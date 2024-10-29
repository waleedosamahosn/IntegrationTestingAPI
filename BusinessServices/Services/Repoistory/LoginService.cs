using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CategoryResponseViewModel;
using static BusinessServices.Reponses.Register_LoginResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class LoginService : ILoginService
    {
        public class RequestDataLogin
        {
            public string mobile { get; set; }
            public string pin { get; set; }
            public string fcmToken { get; set; }
        }

        public async Task<VerifyActionReponse> LoginData(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var client = new HttpClient())
            {
                var RespobseData = new RequestDataLogin
                {
                    mobile = "+201285937961",
                    pin = "123456",
                    fcmToken = ""
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(RespobseData),
                        Encoding.UTF8, "application/json");

                var response = client.PostAsync(requestDto.BaseUrl + "/" +requestDto.Url, c).Result;

                string responseAsString = await response.Content.ReadAsStringAsync();
                var responseLogin = JsonConvert.DeserializeObject<RootAuthenticationViewModel>(responseAsString);

                if (responseLogin != null && responseLogin.code == (int)ResponseStatusEnum.Success)
                {

                    verifyActionReponse.Token = responseLogin.data.jwtToken;

                    verifyActionReponse.RefreshToken = responseLogin.data.refreshToken;

                    verifyActionReponse.IsSuccess = true;

                    verifyActionReponse.Name = "Login";
                    verifyActionReponse.Data = responseLogin;

                    if (responseLogin.data == null)
                    {
                        verifyActionReponse.Message = "Success with empty data";
                    }

                    else
                    {

                        verifyActionReponse.Message = "Success";
                    }
                }
                return verifyActionReponse;
            }

        }

        }
    }
