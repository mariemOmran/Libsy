namespace Project_Angular.Models
{
    public class ProductFilterationModel
    {
        public List<int>? Categories { get; set; }
        public List<int>? Brands { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;  
    }
}
