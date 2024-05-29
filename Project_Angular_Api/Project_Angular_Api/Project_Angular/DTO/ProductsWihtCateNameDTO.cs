using System.ComponentModel.DataAnnotations;

namespace Project_Angular.DTO
{
    public class ProductsWihtCateNameDTO
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qunatity { get; set; }
        public int? Rate { get; set; }

        public string Image { get; set; }
        public string CategoryName { get; set; }
        public string brandName { get; set; }
        
    }
}
