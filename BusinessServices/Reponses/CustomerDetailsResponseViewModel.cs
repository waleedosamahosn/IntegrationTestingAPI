using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class CustomerDetailsResponseViewModel
    {
        public class CartItemDataCustomerDetailsResponse
        {
            public string itemName { get; set; }
            public double price { get; set; }
            public double quantity { get; set; }
            public string itemDescription { get; set; }
            public ItemDataCustomerDetailsResponse itemAttributes { get; set; }
        }

        public class DataCustomerDetailsResponse
        {
            public double storePurchasePrice { get; set; }
            public double bankProfitRate { get; set; }
            public double bankProfit { get; set; }
            public double bankSalePrice { get; set; }
            public double downPayment { get; set; }
            public double monthlyInstallments { get; set; }
            public string currency { get; set; }
            public double tenor { get; set; }
            public bool canAddDealDocs { get; set; }
            public bool canAddAdditionalInfo { get; set; }
            public bool canViewContract { get; set; }
            public bool canCancelDeal { get; set; }
            public List<CartItemDataCustomerDetailsResponse> cartItems { get; set; }
            public object items { get; set; }
        }

        public class ItemDataCustomerDetailsResponse
        {
            public string Type { get; set; }

            [JsonProperty("Chassis No.")]
            public string ChassisNo { get; set; }

            [JsonProperty("Vehicle Make")]
            public string VehicleMake { get; set; }

            [JsonProperty("Engine No.")]
            public string EngineNo { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }

            [JsonProperty("Manufacture Year")]
            public string ManufactureYear { get; set; }

            [JsonProperty("Car Condition")]
            public string CarCondition { get; set; }
            public string Price { get; set; }

            [JsonProperty("Use of Car")]
            public string UseofCar { get; set; }

            [JsonProperty("Car Registration in the Name of:")]
            public string CarRegistrationintheNameof { get; set; }

            [JsonProperty("Name of third party for Registration")]
            public string NameofthirdpartyforRegistration { get; set; }

            [JsonProperty("ID no. of third party")]
            public string IDnoofthirdparty { get; set; }
        }

        public class RootCustomerDetailsResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public DataCustomerDetailsResponse data { get; set; }
        }
    }
}
