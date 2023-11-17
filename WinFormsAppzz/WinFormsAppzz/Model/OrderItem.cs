using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppzz
{
    public class OrderItem
    {
        public long id { get; set; }
        public string name { get; set; }
        public long? price { get; set; }
        public string imageUrl { get; set; }
        public int? quantity { get; set; }
        public long? totalPrice { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? updatedOn { get; set; }

        public int? orderId { get; set; }
    }
}
