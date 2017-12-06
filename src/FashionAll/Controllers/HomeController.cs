using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionAll.Data;
using FashionAll.Models;

namespace FashionAll.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Home
        public async Task<IActionResult> Index(int? id)
        {

            //more than 1 model display on the same view
            ViewModel viewModel = new ViewModel();


            List<Category> listCategory = _context.Categories.ToList();
            List<Bag> listBag = new List<Bag>();

            if (id == null)
            {
                listBag = _context.Bags.ToList(); //list all bags
            }
            else
            {
                listBag = _context.Bags.Where(b => b.CategoryID == id).ToList(); //list bags by category id
            }




            viewModel.Categories = listCategory;
            viewModel.Bags = listBag;

            return View(viewModel);

        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }

        // GET: Bags/Details/5
        public async Task<IActionResult> BagDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bags.SingleOrDefaultAsync(m => m.BagID == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }
    }
}
