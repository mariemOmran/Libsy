using Project_Angular.Models;

namespace Project_Angular.Reposatry
{
    public class UserReposatry : IuserReposatry
    {
        private readonly EcommerceContext db;

        public UserReposatry(EcommerceContext db)
        {
            this.db = db;
        }
        public ApplicationUser User(string userName, string passward)
        {
            throw new NotImplementedException();
        }
    }
}
