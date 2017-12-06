using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionAll.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        public string SupplierName { get; set; }

        public string PhoneNum { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }


        public ICollection<Bag> Bags { get; set; }
    }
}
