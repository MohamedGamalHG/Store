using Microsoft.EntityFrameworkCore;
using Store.Areas.Admin.Services.Base;
using Store.Areas.Admin.Services.InterfaceService;
using Store.Areas.Admin.ViewModels;
using Store.Data;
using Store.Models;

namespace Store.Areas.Admin.Services
{
    public class SubCategoryService : ISubCategoryInterface
    {
        private readonly AppDbContext appDbContext;

        public SubCategoryService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<SubCategory> GetAll()
        {
            return appDbContext.SubCategories.Include(x => x.Category).ToList();
        }

        public SubCategoryViewMdoel? GetById(int id)
        {
            var subCategory = appDbContext.SubCategories.Where(x => x.Id == id).FirstOrDefault();
            SubCategoryViewMdoel subCategoryViewMdoel = new SubCategoryViewMdoel
            {
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId,
            };
            return subCategoryViewMdoel;
        }
        public bool Create(SubCategoryViewMdoel entity)
        {
            try
            {
                SubCategory subCategory = new SubCategory
                {
                    Name = entity.Name,
                    CategoryId = entity.CategoryId,
                };
                appDbContext.SubCategories.Add(subCategory);
                appDbContext.SaveChanges();

            }
            catch (Exception ex) { return false; }

            return true;
        }

        public bool Update(SubCategoryViewMdoel entity, int id)
        {
            var subCategory = appDbContext.SubCategories.Where(x => x.Id == id).FirstOrDefault();
            if (subCategory != null)
            {
                subCategory.Name = entity.Name;
                subCategory.CategoryId = entity.CategoryId;
                appDbContext.Update(subCategory);
                appDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Delete(int id)
        {
            var subCategory = appDbContext.SubCategories.Where(x => x.Id == id).FirstOrDefault();
            if (subCategory != null)
            {
                appDbContext.Remove(subCategory);
                appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
