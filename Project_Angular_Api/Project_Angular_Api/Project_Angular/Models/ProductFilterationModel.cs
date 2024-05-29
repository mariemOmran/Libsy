namespace Project_Angular.Models
{
    public class ProductFilterationModel
    {
        public List<string>? Categories { get; set; }
        public List<string>? Brands { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;  
    }
}
