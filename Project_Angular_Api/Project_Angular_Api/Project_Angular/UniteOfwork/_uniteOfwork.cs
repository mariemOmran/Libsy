using Microsoft.EntityFrameworkCore.Diagnostics;
using Project_Angular.Models;
using Project_Angular.Reposatry;

namespace Project_Angular.UniteOfwork
{
    public class _uniteOfwork
    {
        private readonly EcommerceContext db;
        private GenricReposatry<Clothes> clothes;
        private GenricReposatry<ApplicationUser> users;
        private GenricReposatry<Order> orders;
        private GenricReposatry<order_details> order_detailses;
        private GenricReposatry<Category> categories;
        private GenricReposatry<Brand> brands;
        public _uniteOfwork(EcommerceContext db)
        {
            this.db = db;
            
        }
        public GenricReposatry<Clothes> Clothes {
            get {
                if (clothes == null)
                {
                    clothes = new GenricReposatry<Clothes>(db);
                }
                    return clothes;
            }
        }
        public GenricReposatry<ApplicationUser> Users
        {
            get
            {
                if (users == null)
                {
                    users = new GenricReposatry<ApplicationUser>(db);
                }
                return users;
            }
        }
        public GenricReposatry<Order> Orders
        {
            get {
                if (orders == null) { 
                orders=new GenricReposatry<Order> (db);
                }
                return orders;
            }
        
        }
        public GenricReposatry<order_details> Order_detailses
        {
            get {
                if (order_detailses == null) { 
                order_detailses=new GenricReposatry<order_details> (db);
                }
                return order_detailses;
            
            }
        
        }
        public GenricReposatry<Category> Categories
        {
            get { 
            if(categories == null)
                {
                    categories=new GenricReposatry<Category> (db);
                }
            return categories;
            }
        }
        public GenricReposatry<Brand> Brands
        {
            get {
                if (brands == null) { 
                brands=new GenricReposatry<Brand>  (db);
                }
                return brands;
            }

        }
        public void save() {

            db.SaveChanges();
        }
    }
}
