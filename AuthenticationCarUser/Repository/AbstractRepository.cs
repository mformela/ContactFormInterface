using AuthenticationCarUser.Models;
using AuthenticationCarUser.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AuthenticationCarUser.Repository
{
    public class AbstractRepository<T> where T:class, IBasicEntity // dodajemy dziedziczenie po IBASICENTITY, zeby mieć dostęp do DateCreate i DateMod
    {
        public virtual void Create(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.DateCreate = DateTime.Now; //dzięki temu, że dziedziczym po ibasicentity to możemy to dodać 
                entity.DateMod = DateTime.Now; // jw
                entity.IsActive = true; //jeśli stworzymy to jest aktywny. tutaj również powołujemy się na dostęp do IBasicEntity
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.DateMod = DateTime.Now;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                
            }
        }

        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }
        public virtual void Delete(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                entity.DateMod = DateTime.Now;
                entity.IsActive = false; // data modyfikacji będzie oznaczać datę deaktywacji rekordu. w tym momencie rekord, gdy jest usuwany, przestaje być aktywny i niezalogowany użytkownik nie będzie miał do niego dostępu. 
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}