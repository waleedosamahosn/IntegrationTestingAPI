using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerDealResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ICustomerDealService
    {
        Task<VerifyActionReponse> GetDataCustomer(RequestDto requestDto);
    }
}
