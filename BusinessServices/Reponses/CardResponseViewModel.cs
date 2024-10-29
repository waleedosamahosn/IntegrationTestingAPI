using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class CardResponseViewModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class CartItemCart
        {
            public string itemName { get; set; }
            public int price { get; set; }
            public int quantity { get; set; }
            public string itemDescription { get; set; }
            public ItemAttributesCart itemAttributes { get; set; }
        }

        public class CurrencyCart
        {
            public string currencyName { get; set; }
        }

        public class DataCart
        {
            public string retailerLogo { get; set; }
            public string transactionDate { get; set; }
            public int amount { get; set; }
            public int retailerId { get; set; }
            public List<CartItemCart> cartItems { get; set; }
            public CurrencyCart currency { get; set; }
        }

        public class ItemAttributesCart
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

        public class RootCardResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public DataCart data { get; set; }
        }

    }
}
