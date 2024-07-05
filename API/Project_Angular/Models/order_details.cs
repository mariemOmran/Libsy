using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Angular.Models
{
    public class order_details
    {
        [ForeignKey("order")]
        public int orderID { get; set; }
        [ForeignKey("clothes")]
        public int clothesID { get; set; }
        public int quantity { get; set; }
        [DataType("money")]
        public decimal price { get; set; }
        public Order order { get; set; } = new Order();
        public Clothes clothes { get; set; } = new Clothes();
    }
}
