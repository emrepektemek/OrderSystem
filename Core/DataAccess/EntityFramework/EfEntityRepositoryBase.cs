using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework 
{

    // Bu class ile birlikte her veri tabani tablosu icin CRUD islemleri hazir. Bu isimden sunu anliyoruz Entity framework kullanarak bir repository base (temel) sinifi olustur demektir.
    public class EfEntityRepositoryBase<TEntity,TContext>: IEntityRepository<TEntity> // Generic olarak diyoruz ki bir tane Entity tipi ver bu tablo adi anlimina geliyor, bir tane de context tipi ver bu da veri tabani baglantisinin oldugu ve tablo adlarinin yazılımımızda ki siniflarla eslestirildigi nesnedir.
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // using C# ozelligidir ve icine yazdiginiz nesneler using bittiginde garbage collector tarafından toplanır. Burada bunu yapmamizin nedeni context nesnesinin bellekte cok yer kaplamasidir

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) // parametre olarak göndereceğimiz lambda yani Linq sorgusu
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
