using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CategoryResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<VerifyActionReponse> GetCategoriesData(RequestDto requestDto);
    }
}
