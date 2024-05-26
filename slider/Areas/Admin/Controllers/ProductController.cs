using Microsoft.AspNetCore.Mvc;
using slider.Services.Interface;
using slider.ViewModels.Products;

namespace slider.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var dbProduct = await _productService.GetAllPaginateAsync(page);

            List<ProductVM> mappedDatas = _productService.GetMappedDatas(dbProduct);
            ViewBag.PageCount = await GetPageCountAsync(4);
            ViewBag.currentPage = page;
            return View(mappedDatas);
        }
        private async Task<int> GetPageCountAsync(int take)
        {
            int count = await _productService.GetCountAsync();
            return (int)Math.Ceiling((decimal)count / take);
        }

    }
}
