using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.RetailerResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface IRetailerService
    {
        Task<VerifyActionReponse> GetRetailsData(RequestDto requestDto);
    }
}
