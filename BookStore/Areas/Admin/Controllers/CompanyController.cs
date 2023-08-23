using BookStore.DataAccess.Repository;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
   
        }
        public IActionResult Index()
        {
            List<Company> CompanyList = _unitOfWork.Company.GetAll().ToList(); 
            return View(CompanyList);
        }

        public IActionResult Upsert(int? id)
        { 
            //ViewBag.CategoryList = CategoryList;

            if(id == null || id == 0)
            {
                //Create
                return View(new Company());
            }
            else
            {
                //Update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            
           if(ModelState.IsValid)
            {
                if (companyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company created Successfully";
                return RedirectToAction("Index");
            }
           else
            {
                return View(companyObj);
            }
                
               
            
           
            
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objFromCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objFromCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
      
            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion


    }
}
