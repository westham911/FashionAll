using FashionAll.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionAll.Models
{
    public class ViewModel
    {
        public List<Category> Categories { get; set; }

        public List<Bag> Bags { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public Bag Bag { get; set; }

        public Supplier Supplier { get; set; }


    }
}
