using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class CustomerSearchResponseViewModel
    {
        public class RootCustomerSearchResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }
            public class AdditionalFieldSection
            {
                public object additionalFieldSectionTitle { get; set; }
                public List<CustomControl> customControls { get; set; }
            }

            public class CustomControl
            {
                public string id { get; set; }
                public string type { get; set; }
                public string validationType { get; set; }
                public object source { get; set; }
                public string value { get; set; }
                public string name { get; set; }
                public string englishName { get; set; }
                public string mappedColumnNameInAPI { get; set; }
                public int order { get; set; }
                public bool isDisabled { get; set; }
                public string displayName { get; set; }
                public List<Option> options { get; set; }
            }

            public class Customer
            {
                public string mobileNumber { get; set; }
            }

            public class Data
            {
                public Customer customer { get; set; }
                public List<AdditionalFieldSection> additionalFieldSections { get; set; }
            }

            public class Option
            {
                public string caption { get; set; }
                public string key { get; set; }
            }

        }
    }
