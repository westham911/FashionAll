using System;
using System.Collections.Generic;

namespace FashionAll.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }



        public ICollection<Bag> Bags { get; set; }
    }
}
