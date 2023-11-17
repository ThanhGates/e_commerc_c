using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppzz
{
    public class Customer
    {
        public long id { get; set; }
        public DateTime? createdOn { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public int? role { get; set; }
        public int? sex { get; set; }
        public string username { get; set; }
    }
}
