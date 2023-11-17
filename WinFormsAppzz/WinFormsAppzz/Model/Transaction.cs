using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppzz
{
    public class Transaction
    {
        public long Id { get; set; }
        public int? TransStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Order Order { get; set; }
    }
}
