using slider.Models;

namespace slider.Services.Interface
{
    public interface ICategoriyService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
