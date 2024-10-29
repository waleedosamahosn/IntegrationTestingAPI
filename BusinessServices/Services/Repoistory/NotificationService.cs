using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.NotificationResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class NotificationService : INotificationService
    {
        public class ResponseModelNofify
        {
            public int pageIndex { get; set; }
            public int pageSize { get; set; }
        }

        public async Task<VerifyActionReponse> GetDataNottify(RequestDto requestDto )
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var RespobseData = new ResponseModelNofify
                {
                    pageIndex = 0,
                    pageSize = 10
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(RespobseData),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}");

                var response = await httpclient.PostAsync(requestDto.BaseUrl +"/" + requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;

                    var responseNofification = JsonConvert.DeserializeObject<RootNotificationResponse>(responseData);

                    if (responseNofification != null && responseNofification.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Notification";
                        verifyActionReponse.Data = responseNofification;

                        if (responseNofification.data != null)
                        {
                            verifyActionReponse.Message = "Success";
                        }

                        else
                        {
                            verifyActionReponse.Message = "Success with empty data";
                        }

                    }
                    return verifyActionReponse;

                }

                return verifyActionReponse;
            }
        }
    }
}
