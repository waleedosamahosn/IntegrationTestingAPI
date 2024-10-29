using BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessServices.Reponses.NotificationResponseViewModel;

namespace BusinessServices.Services.Interfaces
{
    public interface INotificationService
    {
        Task<VerifyActionReponse> GetDataNottify(RequestDto requestDto);
    }
}
