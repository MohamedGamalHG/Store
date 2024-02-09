using Store.Areas.Admin.Services.Base;
using Store.Data;
using Store.Models;

namespace Store.Areas.Admin.Services
{
    public class CategoryService : IBaseInterface<Category>
    {
        private readonly AppDbContext appDbContext;

        public CategoryService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Category> GetAll()
        {
            return appDbContext.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            return appDbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
        }
        public bool Create(Category entity)
        {
            try
            {
                appDbContext.Categories.Add(entity);
                appDbContext.SaveChanges();
                
            }catch (Exception ex){ return false;}

            return true;
        }

        public bool Update(Category entity, int id)
        {
           var category =  appDbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (category != null)
            {
                category.Name = entity.Name;
                appDbContext.Update(category);
                appDbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Delete(int id)
        {
            var category = appDbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (category != null)
            {
                appDbContext.Remove(category);
                appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
