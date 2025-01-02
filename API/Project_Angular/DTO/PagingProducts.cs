namespace Project_Angular.DTO
{
    public class PagingProducts
    {
        public List<ProductsWihtCateNameDTO> products { get; set; }    
        public int  PageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
