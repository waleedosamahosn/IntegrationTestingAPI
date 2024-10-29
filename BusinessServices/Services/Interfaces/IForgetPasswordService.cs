using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.ForgetPassResponseModel;

namespace BusinessServices.Services.Interfaces
{
    public interface IForgetPasswordService
    {
        Task<VerifyActionReponse> ResponseDataChanged(RequestDto requestDto);
    }
}
