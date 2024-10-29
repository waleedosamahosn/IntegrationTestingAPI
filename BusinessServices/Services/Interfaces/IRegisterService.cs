using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.Register_LoginResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<VerifyActionReponse> RgisterData(RequestDto requestDto);
    }
}
