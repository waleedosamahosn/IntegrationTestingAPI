using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.ChangedPassResponseModel;

namespace BusinessServices.Services.Interfaces
{
    public interface IChangedPasswordService
    {
        public Task<VerifyActionReponse> changedResponseMehod(RequestDto requestDto);
    }
}
