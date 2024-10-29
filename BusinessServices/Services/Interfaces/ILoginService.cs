using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.Register_LoginResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ILoginService
    {
        Task<VerifyActionReponse> LoginData(RequestDto requestDto);
    }
}
