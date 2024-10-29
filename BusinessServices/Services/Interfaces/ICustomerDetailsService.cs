using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CustomerDetailsResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ICustomerDetailsService
    {
        Task<VerifyActionReponse> GetDataDeal(RequestDto requestDto);
    }
}
