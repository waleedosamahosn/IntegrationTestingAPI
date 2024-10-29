using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.MobileExisResponseModel;

namespace BusinessServices.Services.Interfaces
{
    public interface IMobileExisService
    {
        public Task<VerifyActionReponse> mobileExisResponse(RequestDto requestDto);
    }
}
