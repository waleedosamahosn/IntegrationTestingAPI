using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.BankProductResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface IBankProductservice
    {
        Task<VerifyActionReponse> GetDataBank(RequestDto requestDto);
    }
}
