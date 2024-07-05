using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Angular.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [DataType("money")]
        public decimal Price { get; set; }
        public int Qunatity { get; set; }
        public int? Rate { get; set; }
        
        public string Image {  get; set; }

        [ForeignKey("brand")]
        public int brandID { get; set; }
        [ForeignKey("category")]
        public int categoryID { get; set; }
        public Category category { get; set; }
        public Brand brand { get; set; }

        public virtual List<order_details> _Details { get; set; } = new List<order_details>();

    }
}
