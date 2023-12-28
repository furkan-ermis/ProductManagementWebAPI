using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebAPI.Models;

namespace ProductManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        static int id = 5;
        public static List<Product> _products = new List<Product>()
        {
            new Product(){Id= 1,Name="Lenovo",CategoryId=1,Price=15,Stock=10,IsStatus=true},
            new Product(){Id= 2,Name="Iphone",CategoryId=2,Price=15,Stock=10,IsStatus=true},
            new Product(){Id= 3,Name="Samsung",CategoryId=3,Price=15,Stock=10,IsStatus=true},
            new Product(){Id= 4,Name="Apple",CategoryId=3,Price=15,Stock=10,IsStatus=false},
            new Product(){Id= 5,Name="Apple",CategoryId=3,Price=15,Stock=10,IsStatus=false},
            new Product(){Id= 6,Name="Apple",CategoryId=3,Price=15,Stock=10,IsStatus=false},
            new Product(){Id= 7,Name="Apple",CategoryId=3,Price=15,Stock=10,IsStatus=false},
            new Product(){Id= 8,Name="Apple",CategoryId=3,Price=15,Stock=10,IsStatus=false},
            new Product(){Id= 9,Name="Apple",CategoryId=3,Price=15,Stock=10,IsStatus=false},
            new Product(){Id= 10,Name="Apple",CategoryId=3,Price=15,Stock=10,IsStatus=false},
            new Product(){Id= 11,Name="Apple",CategoryId=3,Price=15,Stock=10,IsStatus=false},
        };
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {

            return _products.Where(x => x.IsStatus).ToList();
        }
        [HttpGet("{id}")]

        public Product GetById(int id)
        {
            var Product = _products.FirstOrDefault(x => x.IsStatus && x.Id == id);
            return Product;
        }
        [HttpGet("{id}/1")]

        public Product GetByCategoryId(int id)
        {
            var Product = _products.FirstOrDefault(x => x.IsStatus && x.CategoryId == id);
            return Product;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Product = _products.FirstOrDefault(x => x.IsStatus && x.Id == id);
            if (Product != null)
            {
                _products.Remove(Product);
                return StatusCode(200);
            }
            return StatusCode(404);

        }
        [HttpPost]
        public IActionResult Post(Product Product)
        {
            id++;
            Product.Id = id;
            if (!String.IsNullOrEmpty(Product.Name))
            {
                _products.Add(Product);
                return StatusCode(200);
            }
            return StatusCode(404);

        }
        [HttpPut]
        public IActionResult Put(Product Product)
        {
            var findProduct = _products.FirstOrDefault(x => x.Id == Product.Id);
            if (findProduct != null)

            {
                findProduct.Name = Product.Name;
                findProduct.IsStatus = Product.IsStatus;
                return Ok(Product.Name + " Ürün güncellendi");
            }
            else
            {
                return Ok("Ürün güncellenmedi");
            }
        }
    }
}
