using e_commerce.Models;
using e_commerce.Repository;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> products = unitOfWork.Product.GetAll().ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Add(product);
                unitOfWork.Save();
                TempData["success"]= "Product created successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            Product? product = unitOfWork.Product.Get(p=>p.Id==id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Update(product);
                unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            Product? product =unitOfWork.Product.Get(p=>p.Id== id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult PostDelete(int? id)
        {
            if(id == null || id < 1)
                return NotFound();
            Product? product = unitOfWork.Product.Get(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            unitOfWork.Product.Remove(product);
            unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
