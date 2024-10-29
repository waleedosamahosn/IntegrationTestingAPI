using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.MobileExisResponseModel;

namespace BusinessServices.Services.Repoistory
{
    public class MobileExisService : IMobileExisService
    {
        public class MobileExisRequest
        {
            public string mobile { get; set; }
        }

        public async Task<VerifyActionReponse> mobileExisResponse(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var _mobileExisRequest = new MobileExisRequest
                {
                    mobile = "+201285937961"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(_mobileExisRequest),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}");

                var response = await httpclient.PostAsync(requestDto.BaseUrl +"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseMobile = JsonConvert.DeserializeObject<MobileExisResponse>(responseData);

                    if (responseMobile != null && responseMobile.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Mobile Exist";
                        verifyActionReponse.Data = responseMobile;

                        if (responseMobile.data == null)
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
