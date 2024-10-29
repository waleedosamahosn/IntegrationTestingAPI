using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerSearchResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ICustomerSearchService
    {
        Task<VerifyActionReponse> SearchCustomerDataDeal(RequestDto requestDto);
    }
}
