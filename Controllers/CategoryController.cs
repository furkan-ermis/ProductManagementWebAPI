using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebAPI.Models;

namespace ProductManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static int id = 4;
        private static List<Category> _categories=new List<Category>()
        {
            new Category(){Id= 1,Name="Bilgisayar",IsStatus=true},
            new Category(){Id= 2,Name="Telefon",IsStatus=true},
            new Category(){Id= 3,Name="Tablet",IsStatus=true},
            new Category(){Id= 4,Name="Beyaz Eşya",IsStatus=false},
        };
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
           
            return _categories.Where(x=>x.IsStatus).ToList();
        }
        [HttpGet("{id}")]

        public Category GetById(int id)
        {
            var category = _categories.FirstOrDefault(x => x.IsStatus && x.Id == id);
            return category;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(x => x.IsStatus && x.Id == id);
            if (category!=null)
            {
                _categories.Remove(category);
            return StatusCode(200);
            }
            return StatusCode(404);

        }
        [HttpPost]
        public IActionResult Post(Category category)
        {
            
            if (!String.IsNullOrEmpty(category.Name))
            {
                id++;
                category.Id = id;
                _categories.Add(category);
                return StatusCode(200);
            }
            return StatusCode(404);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,Category category)
        {
            var findCategory = _categories.FirstOrDefault(x => x.Id == id);
            if (findCategory!=null)

            {
                findCategory.Name = category.Name;
                findCategory.IsStatus = category.IsStatus;
                return Ok(category.Name + " Kategori güncellendi");
            }
            else
            {
                return Ok("Kategori güncellenmedi");
            }
        }

    }
}
