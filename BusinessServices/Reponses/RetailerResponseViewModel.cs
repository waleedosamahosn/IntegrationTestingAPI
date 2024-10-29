using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class RetailerResponseViewModel
    {
        public class RootRetailerResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public List<DataRetailerResponse> data { get; set; }
        }
        public class DataRetailerResponse
        {
            public int retailerId { get; set; }
            public int retailerCode { get; set; }
            public string imageUrl { get; set; }
            public string retailerWesite { get; set; }
            public int categoryId { get; set; }
            public string retailerName { get; set; }
            public object createdBy { get; set; }
            public object creationDate { get; set; }
            public object lastModificationDate { get; set; }
            public object modifiedBy { get; set; }
            public object category { get; set; }
            public object localizations { get; set; }
        }
    }
}
