namespace Project_Angular.DTO
{
    public class AddProduct
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qunatity { get; set; }

        public string Image { get; set; }
        public int Categoryid { get; set; }
        public int brandid { get; set; }
    }
}
