using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionAll.Models
{
    public class Bag
    {
        public int BagID { get; set; }

        public string BagName { get; set; }

        public decimal Price { get; set; }

        public string BagDesc { get; set; }

        public string ImgSrc { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
