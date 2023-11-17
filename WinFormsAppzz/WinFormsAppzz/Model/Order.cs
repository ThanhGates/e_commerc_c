
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppzz
{
    public class Order
    {

        public long id { get; set; }
        public decimal subTotal { get; set; } = 0;
        public decimal shippingPrice { get; set; } = 15000;
        public decimal total { get; set; } = 0;
        public string discount { get; set; }
        public decimal grandTotal { get; set; } = 0;
        public string firstname { get; set; }

        public string lastname { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }

        public string address { get; set; }

        public string district { get; set; }

        public string city { get; set; }
        public string province { get; set; }

        public string content { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? updatedOn { get; set; }

        public int userId { get; set; }
        public List<int> orderItemsId { get; set; }
    }
}
