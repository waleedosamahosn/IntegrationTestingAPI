using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerIdNumberResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class CustomerIdNumberService : ICustomerIdNumberService
    {
        public class CustomerIdNumberRequest
        {
            public string dealCode { get; set; }
        }

        public async Task<VerifyActionReponse> CustomerIdNumberDataDeal(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var _customerIdNumberRequest = new CustomerIdNumberRequest
                {
                    dealCode = "9e018db8-6cf6-4a25-95ce-1f8445824ee7"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(_customerIdNumberRequest),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); //

                var response = await httpclient.PostAsync(requestDto.BaseUrl +"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseIdNumber = JsonConvert.DeserializeObject<RootCustomerIdNumberResponse>(responseData);

                    if (responseIdNumber != null) {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Customer IdNumber";
                        verifyActionReponse.Data = responseIdNumber;

                        if (responseIdNumber.data ==  null)
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
