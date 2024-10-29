using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerDetailsResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class CustomerDetailsService : ICustomerDetailsService
    {
        public class DealDetailsRequest
        {
            public string ifinCode { get; set; }
        }

        public async Task<VerifyActionReponse> GetDataDeal(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var RequestDealDetails = new DealDetailsRequest
                {

                    ifinCode = "3172-6688-818"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(RequestDealDetails),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); //

                var response = await httpclient.PostAsync(requestDto.BaseUrl+"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseDetails = JsonConvert.DeserializeObject<RootCustomerDetailsResponse>(responseData);

                    if (responseDetails != null && responseDetails.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Customer Details";
                        verifyActionReponse.Data = responseDetails;

                        if (responseDetails.data == null)
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
