using e_commerce.Models;
using e_commerce.Repository;
using e_commerce_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Areas.Admin.Controllers
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
        //Company/Index
        public IActionResult Index()
        {
            List<Company> companies = _unitOfWork.Company.GetAll().ToList();
            return View(companies);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if(id == null)
                return View(new Company());

            Company company = _unitOfWork.Company.Get(c => c.Id==id);
            return View(company);
        }
        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(company);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> companies =_unitOfWork.Company.GetAll().ToList();
            return Json(new { data = companies });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            Company companyToBeDeleted =_unitOfWork.Company.Get(c=>c.Id==id);
            if(companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
