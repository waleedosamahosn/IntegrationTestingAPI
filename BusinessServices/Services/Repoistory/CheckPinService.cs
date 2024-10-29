using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CheckBinResponseModel;

namespace BusinessServices.Services.Repoistory
{
    public class CheckPinService : ICheckPinService
    {
        public class CheckPinRequest
        {
            public string mobile { get; set; }
            public string pin { get; set; }
        }

        public async Task<VerifyActionReponse> CheckBinMethod(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var _checkPinRequest = new CheckPinRequest
                {
                    mobile = "+201285937961",
                    pin = "123456"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(_checkPinRequest),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); //

                var response = await httpclient.PostAsync(requestDto.BaseUrl+"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responsePin = JsonConvert.DeserializeObject<RootCheckBinResponse>(responseData);

                    if (responsePin != null &&responsePin.code == (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Check Pin";
                        verifyActionReponse.Data = responsePin;

                        if (responsePin.data == null)
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
