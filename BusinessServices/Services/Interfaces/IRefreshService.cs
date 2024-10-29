using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.RefreshResponseModel;

namespace BusinessServices.Services.Interfaces
{
    public interface IRefreshService
    {
        public Task<VerifyActionReponse> GetRefreshMethod(RequestDto requestDto);
    }
}
