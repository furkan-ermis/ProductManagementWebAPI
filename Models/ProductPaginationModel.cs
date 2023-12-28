namespace ProductManagementWebAPI.Models
{
    public class ProductPaginationModel
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public List<Product> Products { get; set; }
    }
}
