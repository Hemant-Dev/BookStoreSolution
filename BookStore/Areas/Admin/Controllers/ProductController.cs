using BookStore.DataAccess.Repository;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll().ToList(); 
            return View(productList);
        }

        public IActionResult Create()
        { 
            //ViewBag.CategoryList = CategoryList;
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };

            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (productVM.Product == null) { return NotFound(); }
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().
                    Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
            }
            return View(productVM);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null ) { return NotFound(); }
            Product objFromEdit = _unitOfWork.Product.Get(u => u.Id == id);
            return View(objFromEdit);
        }
        [HttpPost]
        public IActionResult Edit(Product objFromEdit)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Product.Update(objFromEdit);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();  
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            Product objFromDelete = _unitOfWork.Product.Get(u => u.Id == id);
            return View(objFromDelete);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if(id == null) { return NotFound(); }  
            Product objFromDelete = _unitOfWork.Product.Get(u => u.Id==id);
            if(objFromDelete == null) { return NotFound(); }
            _unitOfWork.Product.Remove(objFromDelete);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
