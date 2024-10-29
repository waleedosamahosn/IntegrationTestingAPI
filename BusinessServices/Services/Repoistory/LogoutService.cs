using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.LogoutReponseModel;

namespace BusinessServices.Services.Repoistory
{
    public class LogoutService : ILogoutService
    {
        public class LogoutRequest
        {
            public string refreshToken { get; set; }
        }

        public async Task<VerifyActionReponse> ExecLogoutMethod(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var _logoutRequest = new LogoutRequest
                {
                    refreshToken = requestDto.RefreshToken
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(_logoutRequest),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}");

                var response = await httpclient.PostAsync(requestDto.BaseUrl +"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseLogout = JsonConvert.DeserializeObject<RootLogoutReponse>(responseData);

                    if (responseLogout != null && responseLogout.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Logout";
                        verifyActionReponse.Data = responseLogout;

                        if (responseLogout.data == null)
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

                else
                {
                    return verifyActionReponse;
                }

            }
        }
    }
}
