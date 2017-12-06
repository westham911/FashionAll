using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionAll.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string PhoneNum { get; set; }

        public int Role { get; set; }


        public ICollection<OrderDetail> Bags { get; set; }
    }
}
