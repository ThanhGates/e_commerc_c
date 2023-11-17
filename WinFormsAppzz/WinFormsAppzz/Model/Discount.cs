using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppzz
{
    public class Discount
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public double Percentage { get; set; }
        public int DiscountFor { get; set; }
        public int DiscountType { get; set; }
        public long Quantity { get; set; }
        public string content { get; set; }
    }
}
