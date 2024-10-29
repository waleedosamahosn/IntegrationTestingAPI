using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CheckBinResponseModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ICheckPinService
    {
        public Task<VerifyActionReponse> CheckBinMethod(RequestDto requestDto);
    }
}
