using Project_Angular.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_Angular.DTO
{
    public class OrderDetailsDTO {
        public string clothesName { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
    public class OrderDto
    {

        public decimal totalPrice { get; set; }
        public TimeSpan time { get; set; }
        public string userName { get; set; }


        public OrderDetailsDTO orderDetailsDTO { get; set; }
    }
}
