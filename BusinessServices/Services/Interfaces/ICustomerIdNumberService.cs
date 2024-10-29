using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerIdNumberResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ICustomerIdNumberService
    {
        Task<VerifyActionReponse> CustomerIdNumberDataDeal(RequestDto requestDto);
    }
}
