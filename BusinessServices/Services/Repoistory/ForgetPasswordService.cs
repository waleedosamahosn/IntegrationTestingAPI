using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.ForgetPassResponseModel;

namespace BusinessServices.Services.Repoistory
{
    public class ForgetPasswordService : IForgetPasswordService
    {
        public class ForgetPassRequestBody
        {
            public string mobile { get; set; }
            public string pin { get; set; }
        }

        public async Task<VerifyActionReponse> ResponseDataChanged(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var ResponseDataChamge = new ForgetPassRequestBody
                {
                    mobile = "+201285937961",
                    pin = "123456"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(ResponseDataChamge),
                        Encoding.UTF8, "application/json");

                var response = await httpclient.PostAsync(requestDto.BaseUrl +"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responsePassword = JsonConvert.DeserializeObject<ForgetPassResponse>(responseData);

                    if (responsePassword != null && responsePassword.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Forget Password";
                        verifyActionReponse.Data = responsePassword;

                        if (responsePassword.data == null)
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
