using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerDealResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class CustomerDealService : ICustomerDealService
    {
        public async Task<VerifyActionReponse> GetDataCustomer(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); //

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestDto.BaseUrl+"/"+requestDto.Url);

                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseCustDeal = JsonConvert.DeserializeObject<RootCustomerDealResponse>(responseData);

                    if (responseCustDeal != null && responseCustDeal.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Customer Deal";
                        verifyActionReponse.Data = responseCustDeal;

                        if (responseCustDeal.data == null)
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

                return verifyActionReponse;
            }
        }

    }
}
