using BusinessServices.Dto;
using BusinessServices.Enums;
using BusinessServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CategoryResponseViewModel;
using static BusinessServices.Reponses.RetailerResponseViewModel;

namespace BusinessServices.Services.Repoistory
{
    public class RetailerService : IRetailerService
    {
        public async Task<VerifyActionReponse> GetRetailsData(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync(requestDto.BaseUrl + "/" + requestDto.Url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsestring = response.Content.ReadAsStringAsync().Result;

                    var responseRetailer = System.Text.Json.JsonSerializer.Deserialize<RootRetailerResponse>(responsestring);

                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    if (responseRetailer != null && responseRetailer.code == 
                        (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "Retailer";
                        verifyActionReponse.Data = responseRetailer;

                        if (responseRetailer.data.Count > 0)
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
