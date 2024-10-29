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
using static BusinessServices.Reponses.CustomerSearchResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class CustomerSearchService : ICustomerSearchService
    {
        public class CustomerSearchRequest
        {
            public string customerIdNumber { get; set; }
            public string dealCode { get; set; }
        }

        public async Task<VerifyActionReponse> SearchCustomerDataDeal(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var _customerSearchRequest = new CustomerSearchRequest
                {
                    customerIdNumber = "2002",
                    dealCode = "48aa5ca0-6997-4aff-a05a-cb4c0b23065f"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(_customerSearchRequest),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); //

                var response = await httpclient.PostAsync(requestDto.BaseUrl +"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseSearch = JsonConvert.DeserializeObject<RootCustomerSearchResponse>(responseData);

                    if (responseSearch != null)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Customer Search";
                        verifyActionReponse.Data = responseSearch;

                        if ( responseSearch.data != null )
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

                else
                {
                    return verifyActionReponse;
                }

            }

        }
    }
}
