using Microsoft.AspNetCore.Identity;

namespace Project_Angular.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string Address { get; set; }
        public virtual List<Order> orders { get; set; }=new List<Order>();
    }
}
