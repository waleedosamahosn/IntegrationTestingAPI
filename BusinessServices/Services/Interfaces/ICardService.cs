using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.CardResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface ICardService
    {
        Task<VerifyActionReponse> GetDataCard(RequestDto requestDto);
    }
}
