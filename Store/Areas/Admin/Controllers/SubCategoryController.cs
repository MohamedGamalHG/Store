using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Areas.Admin.Services.Base;
using Store.Areas.Admin.Services.InterfaceService;
using Store.Areas.Admin.ViewModels;
using Store.Data;
using Store.Models;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryInterface subCategoryInterface;
        private readonly AppDbContext context;

        public SubCategoryController(ISubCategoryInterface subCategoryInterface,AppDbContext context)
        {
            this.subCategoryInterface = subCategoryInterface;
            this.context = context;
        }
        public IActionResult Index()
        {
            var subCategories = subCategoryInterface.GetAll();
            
            return View(subCategories);
        }

        public IActionResult Create()
        {
            List<SelectListItem> categories = context.Categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(SubCategoryViewMdoel subCategory)
        {
            if (ModelState.IsValid)
            {
                bool check = subCategoryInterface.Create(subCategory);
                if (check) return RedirectToAction("Index");
            }
            return View(subCategory);
        }

        public IActionResult Edit(int id)
        {
            var category = subCategoryInterface.GetById(id);
            List<SelectListItem> categories = context.Categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Categories = categories;
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(SubCategoryViewMdoel subCategory, int id)
        {
            if (ModelState.IsValid)
            {
                bool check = subCategoryInterface.Update(subCategory, id);
                if (check) return RedirectToAction("Index");
            }
            return View(subCategory);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool check = subCategoryInterface.Delete(id);

            return Json(new { code = 200, message = "Deleted Done", status = true });

        }
    }
}
