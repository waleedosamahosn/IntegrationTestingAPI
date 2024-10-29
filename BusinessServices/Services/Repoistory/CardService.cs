using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CardResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class CardService : ICardService
    {
        public class CardRequestBody
        {
            public string? dealCode { get; set; }
        }

        public async Task<VerifyActionReponse> GetDataCard(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {

                var RespobseDataBank = new CardRequestBody
                {
                    dealCode = "69b22a7a-9aa5-4111-8805-95d68abd92ee"
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(RespobseDataBank),
                        Encoding.UTF8, "application/json");

                httpclient.DefaultRequestHeaders.Add("Authorization", $"Bearer {requestDto.Token}"); 

                var response = await httpclient.PostAsync(requestDto.BaseUrl+"/"+requestDto.Url, c);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;

                    var responseCard = JsonConvert.DeserializeObject<RootCardResponse>(responseData);

                    if (responseCard != null && responseCard.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Cart";
                        verifyActionReponse.Data = responseCard;

                        if (responseCard.data == null)
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
