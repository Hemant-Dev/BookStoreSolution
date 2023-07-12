using BookStore.Data;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Product> objFromIndex = _db.MyProducts.ToList();
            return View(objFromIndex);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if(ModelState.IsValid)
            {
                _db.MyProducts.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? objFromEdit = _db.MyProducts.Find(id);
            return View(objFromEdit);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _db.MyProducts.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == 0 || id == null) { return NotFound(); }
            Product? objFromDelete = _db.MyProducts.Find(id);
            return View(objFromDelete);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if(id == 0 || id == null) { return NotFound(); }
            Product? deleteObj = _db.MyProducts.Find(id);
            if(deleteObj == null) { return NotFound(); }    
            _db.MyProducts.Remove(deleteObj); 
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
