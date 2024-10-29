using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.ChangedPassResponseModel;

namespace BusinessServices.Services.Repoistory
{
    public class ChangedPasswordService : IChangedPasswordService
    {
        public class ChangedPasswordRequest
        {
            public string mobile { get; set; }
            public string oldPin { get; set; }
            public string pin { get; set; }
        }

        public async Task<VerifyActionReponse> changedResponseMehod(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();


            using (var httpclient = new HttpClient())
            {

                var _ChangedPasswordRequest = new ChangedPasswordRequest
                {
                    mobile = "+201285937961",
                    pin = "123456",
                    oldPin = "123456"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(_ChangedPasswordRequest),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}");

                var response = await httpclient.PostAsync(requestDto.BaseUrl +"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responsePass = JsonConvert.DeserializeObject<ChangedPassResponse>(responseData);

                    if (responsePass != null && responsePass.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Change Password";
                        verifyActionReponse.Data = responsePass;

                        if (responsePass.data == null)
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
