using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class BankProductResponseViewModel
    {
        public class CurrencyBankProductResponse
        {
            public string currencyName { get; set; }
        }

        public class DataBankProductResponse
        {
            public int productCode { get; set; }
            public int bankCode { get; set; }
            public string bankLogo { get; set; }
            public string productName { get; set; }
            public double tenure { get; set; }
            public double downPayment { get; set; }
            public double installmentAmount { get; set; }
            public double fees { get; set; }
            public string bankName { get; set; }
            public double maxTenure { get; set; }
            public double minTenure { get; set; }
            public double minDownPayment { get; set; }
            public double maxDownPayment { get; set; }
            public double financeAmount { get; set; }
            public double totalPaidAmount { get; set; }
            public object charges { get; set; }
            public double chargesTotal { get; set; }
            public CurrencyBankProductResponse currency { get; set; }
        }

        public class RootBankProductResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public List<DataBankProductResponse> data { get; set; }
        }
    }
}
