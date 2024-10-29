using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.RefreshResponseModel;

namespace BusinessServices.Services.Repoistory
{
    public class RefreshService : IRefreshService
    {
        public async Task<VerifyActionReponse> GetRefreshMethod(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); //

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,requestDto.BaseUrl +"/"+requestDto.Url + requestDto.RefreshToken);

                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseRefresh = JsonConvert.DeserializeObject<RootRefreshResponse>(responseData);

                    if (responseRefresh != null && responseRefresh.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Refresh";
                        verifyActionReponse.Data = responseRefresh;

                        if (responseRefresh.data == null)
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
