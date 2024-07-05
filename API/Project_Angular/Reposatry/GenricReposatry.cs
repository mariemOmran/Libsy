using Project_Angular.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Project_Angular.Reposatry
{
    public class GenricReposatry<T> where T : class
    {
        private readonly EcommerceContext db;

        public GenricReposatry(EcommerceContext db) {
            this.db = db;
        }

        public IQueryable<T> selectAll() { 
            return db.Set<T>();
        }
        public T getByID(int id)
        {
            return db.Set<T>().Find(id);
        }
        public T Delete(int id)
        {
            T  t =   db.Set<T>().Find(id);
            db.Entry(t).State=EntityState.Deleted;
           
            return t;
        }
        public T update(T t)
        {
            db.Entry(t).State = EntityState.Modified;
            return t; 
        }
        public T add(T entity) {
        db.Entry(entity).State = EntityState.Added;
            return  entity;
        }
        public void save() {
            db.SaveChanges();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includedProperties)
        {
            IQueryable<T> query = selectAll();
            foreach (var includedProperty in includedProperties)
            {
                query = query.Include(includedProperty);
            }
            return query;
        }
        public IQueryable<T> Filters(params Expression<Func<T, bool>>[] LandFilters)
        {
            IQueryable<T> query = selectAll();
            foreach (var includedProperty in LandFilters)
            {
                query = query.Where(includedProperty);
            }
            return query;
        }
        public T SearchingForSpecificITem( Expression<Func<T, bool>> includedProperty)
        {
            T query = db.Set<T>().Where(includedProperty).FirstOrDefault();
            return query;
        }

    }
}
