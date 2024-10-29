using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerAdditionalResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ICustomerAdditinalService
    {
        Task<VerifyActionReponse> CustomerFieldDataDeal(RequestDto requestDto);
    }
}
