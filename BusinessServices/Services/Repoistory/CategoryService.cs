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

namespace BusinessServices.Services.Repoistory
{
    public class CategoryService : ICategoryService
    {
        public async Task<VerifyActionReponse> GetCategoriesData(RequestDto requestDto)
        {
            VerifyActionReponse verifyActionReponse = new VerifyActionReponse();

            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync(requestDto.BaseUrl + "/" + requestDto.Url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responsestring = await response.Content.ReadAsStringAsync();

                    var categoryResponse = System.Text.Json.JsonSerializer.Deserialize<CategoryResponse>(responsestring);
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    if (categoryResponse != null &&
                        categoryResponse.code == (int) ResponseStatusEnum.Success)
                    {
                        verifyActionReponse.IsSuccess = true;

                        verifyActionReponse.Name = "category";

                        verifyActionReponse.Data = categoryResponse;

                        if (categoryResponse.data.Count > 0)
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
