using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppzz
{
    public class Product
    {
        public long id { get; set; }

        public string name { get; set; }
        public long? price { get; set; }

        public long? discountPrice { get; set; }

        public string imageUrl { get; set; }

        public int? quantity { get; set; }

        public int? soldQuantity { get; set; }

        public string content { get; set; }

        public DateTime? createdOn { get; set; }
        public DateTime? updatedOn { get; set; }

        public int categoryId { get; set; }
    }
}
