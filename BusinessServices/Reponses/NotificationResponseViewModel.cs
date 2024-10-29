using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class NotificationResponseViewModel
    {
        public class DataNotificationResponse
        {
            public List<NotificationResponseDto> notificationResponseDtos { get; set; }
            public int notificationCount { get; set; }
        }

        public class NotificationResponseDto
        {
            public int notificationId { get; set; }
            public int notificationTypeId { get; set; }
            public string subject { get; set; }
            public string body { get; set; }
            public string creationDate { get; set; }
            public string mobile { get; set; }
            public string dealCode { get; set; }
            public bool isSeen { get; set; }
            public string retailerLogo { get; set; }
            public bool isExpired { get; set; }
        }

        public class RootNotificationResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public DataNotificationResponse data { get; set; }
        }
    }
}
