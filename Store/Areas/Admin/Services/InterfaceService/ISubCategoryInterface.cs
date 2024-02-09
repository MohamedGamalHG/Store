using Store.Areas.Admin.ViewModels;
using Store.Models;

namespace Store.Areas.Admin.Services.InterfaceService
{
    public interface ISubCategoryInterface
    {
        List<SubCategory> GetAll();
        SubCategoryViewMdoel GetById(int id);
        bool Create(SubCategoryViewMdoel entity);
        bool Update(SubCategoryViewMdoel entity, int id);
        bool Delete(int id);
    }
}
