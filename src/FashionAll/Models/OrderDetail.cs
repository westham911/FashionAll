using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionAll.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }

        public Bag Bag { get; set; }

    }
}
