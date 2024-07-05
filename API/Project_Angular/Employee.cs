using Microsoft.EntityFrameworkCore.Query;

namespace Project_Angular
{
    public interface interface1
    {
        public void print();
    }
    public interface interface2
    {
        public void print();
    }
    public class Employee:interface1,interface2
    {
       
        public void print()
        {
            Console.WriteLine("this is print funtion");
        }
        void interface2.print()
        {
            Console.WriteLine("this is print funtion");
        }
    }
}
