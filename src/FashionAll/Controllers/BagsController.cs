using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionAll.Data;
using FashionAll.Models;
using System.Net.Http.Headers; 
using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.Http; 
using System.IO;


namespace FashionAll.Controllers
{

    public class BagsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostingEnvironment _hostingEnv;

        public BagsController(ApplicationDbContext context,  IHostingEnvironment hEnv)
        {
            _context = context;
            _hostingEnv = hEnv;
        }

        // GET: Bags
        public async Task<IActionResult> Index(string sortOrder, string currentFilter,string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var bags = from s in _context.Bags
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                bags = bags.Where(s => s.BagName.Contains(searchString)
                                       || s.BagDesc.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    bags = bags.OrderByDescending(s => s.BagName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Bag>.CreateAsync(bags.AsNoTracking(), page ?? 1, pageSize));
            //return View(await _context.Bags.ToListAsync());
        }

        // GET: Bags/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Bags/Create
        public IActionResult Create()
        {
            PopulateCategoriesDropDownList();
            PopulateSuppliersDropDownList();
            return View();
        }

        // POST: Bags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BagID,BagDesc,BagName,CategoryID,ImgSrc,Price,SupplierID")] Bag bag, IList<IFormFile> _files)
        {
            if (ModelState.IsValid)
            {
                var relativeName = "";
                var fileName = "";

                if (_files.Count < 1)
                {
                    relativeName = "/images/mk/mk_1.png";
                }
                else
                {
                    foreach (var file in _files)
                    {
                        fileName = ContentDispositionHeaderValue
                                          .Parse(file.ContentDisposition)
                                          .FileName
                                          .Trim('"');
                        //Path for localhost
                        relativeName = "/images/bags/" + DateTime.Now.ToString("ddMMyyyy-HHmmssffffff") + fileName;

                        using (FileStream fs = System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                        {
                            await file.CopyToAsync(fs);
                            fs.Flush();
                        }
                    }
                }
                bag.ImgSrc = relativeName;
                try
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(bag);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }
                catch (DbUpdateException /* ex */)
                {
                    
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists " + "see your system administrator.");
                }

            }
            return View(bag);
        }

        // GET: Bags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            PopulateCategoriesDropDownList();
            PopulateSuppliersDropDownList();

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

        // POST: Bags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BagID,BagDesc,BagName,CategoryID,ImgSrc,Price,SupplierID")] Bag bag, IList<IFormFile> _files)
        {
            if (id != bag.BagID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var relativeName = "";
                var fileName = "";

                if (_files.Count < 1)
                {
                    relativeName = "/images/error.png";
                }

                else
                {
                    foreach (var file in _files)
                    {
                        fileName = ContentDispositionHeaderValue
                                          .Parse(file.ContentDisposition)
                                          .FileName
                                          .Trim('"');
                        //Path for localhost
                        relativeName = "/images/bags/" + DateTime.Now.ToString("ddMMyyyy-HHmmssffffff") + fileName;

                        using (FileStream fs = System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                        {
                            await file.CopyToAsync(fs);
                            fs.Flush();
                        }
                    }
                }
                bag.ImgSrc = relativeName;






                try
                {
                    if (ModelState.IsValid)
                    {
                        _context.Update(bag);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagExists(bag.BagID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists " + "see your system administrator.");
                    }
                }
                return RedirectToAction("Index");
            }
            return View(bag);
        }

        // GET: Bags/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Bags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bag = await _context.Bags.SingleOrDefaultAsync(m => m.BagID == id);
            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BagExists(int id)
        {
            return _context.Bags.Any(e => e.BagID == id);
        }

        private void PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            var categoriesQuery = from d in _context.Categories
                                   orderby d.CategoryName
                                   select d;
            ViewBag.CategoryID = new SelectList(categoriesQuery.AsNoTracking(), "CategoryID", "CategoryName",
            selectedCategory);
        }

        private void PopulateSuppliersDropDownList(object selectedSupllier = null)
        {
            var suppliersQuery = from d in _context.Suppliers
                                  orderby d.SupplierName
                                  select d;
            ViewBag.SupplierID = new SelectList(suppliersQuery.AsNoTracking(), "SupplierID", "SupplierName",
            selectedSupllier);
        }
    }
}
