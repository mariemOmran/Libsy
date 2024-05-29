using Project_Angular.Models;

namespace Project_Angular.Reposatry
{
    public interface IuserReposatry
    {
        public ApplicationUser User(string userName, string passward);
    }
}
