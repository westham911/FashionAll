using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FashionAll.Data;

namespace FashionAll.Models
{
    public static class DbInitializer
    {
            public static void Initialize(ApplicationDbContext context)
            {
                context.Database.EnsureCreated();

                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                // Init category
                var categories = new Category[]
                {
                                    new Category{CategoryName="Totes"},
                                    new Category{CategoryName="Satchels"},
                                    new Category{CategoryName="Shoulder Bags"},
                                    new Category{CategoryName="Crossbodies"},
                                    new Category{CategoryName="Wallets"},
                                    new Category{CategoryName="Clutches & Wristlets"},
                                    new Category{CategoryName="Backpacks, Duffels & Luggage"}
                };
                foreach (Category c in categories)
                {
                    context.Categories.Add(c);
                }
                context.SaveChanges();



                // Init supplier
                var suppliers = new Supplier[]
                {
                                    new Supplier{SupplierName="MICHAEL KORS", PhoneNum="051-5323421", Address="Los angeles, California, USA", EmailAddress="micheal_kors@gmail.com"},
                                    new Supplier{SupplierName="Furla", PhoneNum="031-3232242", Address="Roma, Italy", EmailAddress="furla@gmail.com"}
                };
                foreach (Supplier s in suppliers)
                {
                    context.Suppliers.Add(s);
                }
                context.SaveChanges();



                // Init bag
                var bags = new Bag[]
                {
                            new Bag{BagName="MICHAEL KORS S1", Price=298, BagDesc="Hamilton Large Leather Satchel", ImgSrc="/images/mk/mk_1.png", CategoryID=2, SupplierID=1}
 
                };
                foreach (Bag b in bags)
                {
                    context.Bags.Add(b);
                }
                context.SaveChanges();


        }
        }
}
