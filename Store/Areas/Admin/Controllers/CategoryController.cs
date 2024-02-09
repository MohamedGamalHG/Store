using Microsoft.AspNetCore.Mvc;
using Store.Areas.Admin.Services.Base;
using Store.Models;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IBaseInterface<Category> baseInterface;

        public CategoryController(IBaseInterface<Category> baseInterface)
        {
            this.baseInterface = baseInterface;
        }
        public IActionResult Index()
        {
            var categories = baseInterface.GetAll();
            return View(categories);
        }       

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                bool check = baseInterface.Create(category);
                if (check)  return RedirectToAction("Index"); 
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = baseInterface.GetById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category,int id)
        {
            if (ModelState.IsValid)
            {
                bool check = baseInterface.Update(category, id);
                if (check) return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool check = baseInterface.Delete(id);

            return Json(new { code = 200,message = "Deleted Done",status = true });
             
        }
    }

    public class JsonResponseViewModel
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; } = string.Empty;
    }
}
