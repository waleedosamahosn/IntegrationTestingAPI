using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class CustomerDealResponseViewModel
    {
        public class DealDataCustomerDealResponse
        {
            public string imageUrl { get; set; }
            public string retailerWesite { get; set; }
            public string creationDate { get; set; }
            public string organizationName { get; set; }
            public double contractAmount { get; set; }
            public string categoryName { get; set; }
            public string approvalStatus { get; set; }
            public string statusName { get; set; }
            public string color { get; set; }
            public string ifinCode { get; set; }
            public bool canAddDealDocs { get; set; }
            public bool canAddAdditionalInfo { get; set; }
            public bool canCancelDeal { get; set; }
            public bool canViewContract { get; set; }
            public CurrencyDealDataCustomerDealResponse currency { get; set; }
        }

        public class CancelCustomerDealResponse
        {
            public string imageUrl { get; set; }
            public string retailerWesite { get; set; }
            public string creationDate { get; set; }
            public string organizationName { get; set; }
            public double contractAmount { get; set; }
            public string categoryName { get; set; }
            public string approvalStatus { get; set; }
            public string statusName { get; set; }
            public string color { get; set; }
            public string ifinCode { get; set; }
            public bool canAddDealDocs { get; set; }
            public bool canAddAdditionalInfo { get; set; }
            public bool canCancelDeal { get; set; }
            public bool canViewContract { get; set; }
            public CurrencyDealDataCustomerDealResponse currency { get; set; }
        }

        public class CurrencyDealDataCustomerDealResponse
        {
            public string currencyName { get; set; }
        }

        public class DataCustomerDealResponse
        {
            [JsonProperty("All Deals")]
            public List<DealDataCustomerDealResponse> AllDeals { get; set; }
            public List<CancelCustomerDealResponse> Cancelled { get; set; }
            public List<PrintedCustomerDealResponse> Printed { get; set; }
        }

        public class PrintedCustomerDealResponse
        {
            public string imageUrl { get; set; }
            public string retailerWesite { get; set; }
            public string creationDate { get; set; }
            public string organizationName { get; set; }
            public double contractAmount { get; set; }
            public string categoryName { get; set; }
            public string approvalStatus { get; set; }
            public string statusName { get; set; }
            public string color { get; set; }
            public string ifinCode { get; set; }
            public bool canAddDealDocs { get; set; }
            public bool canAddAdditionalInfo { get; set; }
            public bool canCancelDeal { get; set; }
            public bool canViewContract { get; set; }
            public CurrencyDealDataCustomerDealResponse currency { get; set; }
        }

        public class RootCustomerDealResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public DataCustomerDealResponse data { get; set; }
        }
    }
}
