using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.LogoutReponseModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ILogoutService
    {
        public Task<VerifyActionReponse> ExecLogoutMethod(RequestDto requestDto);
    }
}
