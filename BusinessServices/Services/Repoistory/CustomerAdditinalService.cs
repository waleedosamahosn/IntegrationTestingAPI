using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerAdditionalResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class CustomerAdditinalService : ICustomerAdditinalService
    {
        VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

        public class CustomerFieldRequest
        {
            public string dealCode { get; set; }
        }

        public async Task<VerifyActionReponse> CustomerFieldDataDeal(RequestDto requestDto)
        {
            using (var httpclient = new HttpClient())
            {

                var _customerFieldRequest = new CustomerFieldRequest
                {
                    dealCode = "9e018db8-6cf6-4a25-95ce-1f8445824ee7"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(_customerFieldRequest),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); //

                var response = await httpclient.PostAsync(requestDto.BaseUrl+"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseAdditin = JsonConvert.DeserializeObject<RootCustomerAdditionalResponse>(responseData);

                    verifyActionReponse.IsSuccess = true;

                    if (responseAdditin != null && responseAdditin.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Customer Additional";
                        verifyActionReponse.Data = responseAdditin;

                        if (responseAdditin.data.Count > 0)
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
