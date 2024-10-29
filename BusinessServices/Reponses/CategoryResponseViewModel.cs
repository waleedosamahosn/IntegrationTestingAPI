using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Reponses
{
    public class CategoryResponseViewModel
    {
        public static implicit operator CategoryResponseViewModel(DataCategoryResponse v)
        {
            throw new NotImplementedException();
        }

        public class CategoryResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public List<DataCategoryResponse> data { get; set; }
        }
        public class DataCategoryResponse
        {
            public int categoryId { get; set; }
            public object iconUrl { get; set; }
            public string categoryName { get; set; }
            public List<object> categoryAdvertisements { get; set; }
        }

    }
}
