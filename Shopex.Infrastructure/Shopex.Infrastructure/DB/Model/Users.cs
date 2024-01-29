using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Infrastructure.DB.Model
{
    public class Users
    {
        public int? user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public bool? is_active { get; set; }
        public DateTime? last_login { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public ICollection<Orders> orders { get; set; }
        public ICollection<Carts> carts { get; set; }
        public ICollection<Address> address { get; set; }
    }
}
