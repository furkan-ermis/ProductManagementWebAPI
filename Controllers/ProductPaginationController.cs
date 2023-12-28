using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebAPI.Models;

namespace ProductManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPaginationController : ControllerBase
    {
        [HttpGet("page/{page}")]
        public ProductPaginationModel Get(int page)
        {
            var model = new ProductPaginationModel();
            model.Products = ProductController._products.Skip(5*(page-1)).Take(5).ToList();
            model.PageCount= (int)Math.Ceiling(ProductController._products.Count / 5.0);
            model.CurrentPage = page;
            return model;
        }

        [HttpGet("{search}/{page}")]
        public ProductPaginationModel Get(string search,int page)
        {
            var model = new ProductPaginationModel();
            model.Products = ProductController._products.Where(x => x.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1).Skip(5 * (page - 1)).Take(5).ToList();
            model.PageCount = (int)Math.Ceiling(ProductController._products.Where(x => x.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) != -1).ToList().Count / 5.0);
            return model;
        }


    }
}
