using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.BankProductResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class BankProductservice : IBankProductservice
    {
        public class BankResponseData
        {
            public string? dealCode { get; set; }
        }

        public async Task<VerifyActionReponse> GetDataBank(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var RespobseDataBank = new BankResponseData
                {

                    dealCode = "9e018db8-6cf6-4a25-95ce-1f8445824ee7"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(RespobseDataBank),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); //

                var response = await httpclient.PostAsync(requestDto.BaseUrl +"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseBank = JsonConvert.DeserializeObject<RootBankProductResponse>(responseData);

                    if (responseBank != null && responseBank.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Bank";
                        verifyActionReponse.Data = responseBank;

                        if (responseBank.data.Count > 0)
                        {
                            verifyActionReponse.Message = "success";
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
