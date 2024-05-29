using System.ComponentModel.DataAnnotations;

namespace Project_Angular.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual List<Clothes> Clothes { get; set; } = new List<Clothes>();

    }
}
