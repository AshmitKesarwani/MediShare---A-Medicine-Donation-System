using MediShare.Models;

namespace MediShare.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
    }
}
