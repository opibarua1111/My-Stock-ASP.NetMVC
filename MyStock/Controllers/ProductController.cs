using DailyExpenses.Data;
using Microsoft.AspNetCore.Mvc;
using MyStock.Models;

namespace MyStock.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ProductController(ApplicationDBContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = from i in _db.products
                       orderby i.CategoryName ascending, 
                               i.BuyPrice descending, 
                               i.SellPrice descending
                               select i;

            return View(objProductList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Your Product recorded successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _db.products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Your Product Edit successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _db.products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.products.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Your Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
