using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Angular.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DataType("money")]
        public decimal totalPrice { get; set; }
        [DataType("time")]
        public TimeSpan time {  get; set; }

        [ForeignKey("user")]
        public int user_id { get; set; }
        public ApplicationUser user { get; set; }


        public virtual List<order_details>_Details { get; set; } = new List<order_details>();
    }
}
