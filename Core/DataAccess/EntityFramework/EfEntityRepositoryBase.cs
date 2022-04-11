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
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity , new() //TEntity IEntity tipinde newlenebilir bir class olmalıdır.
        where TContext: DbContext , new() //TContext Dbcontext dpinde olmalı ve newlenebilmeli.

    {
        public void Add(TEntity entity)
        {
            //TContext context = new TContext() bu şekildede newlenebilir using yerine ama performansı etkiler
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())//Using içine yazılan nesneler using bitince belelkten silinir.Buda kodu performanslı çalıştırır.
            {
                var addetEntity = context.Entry(entity);// Veri kaynağına göndereceğim değeri ilişkilendir.
                addetEntity.State = EntityState.Added; //? araştır
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())//Using içine yazılan nesneler using bitince belelkten silinir.Buda kodu performanslı çalıştırır.
            {
                var deletedEntity = context.Entry(entity);// Veri kaynağına göndereceğim değeri ilişkilendir.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext contex = new TContext())
            {
                //SingleOrDefault: anahtar sözcüğü ile dizi içerisinde bulunan elemanlardan
                //belirlenen koşula göre sadece bir tanesinin gelmesini sağlar
                //Dbden seçilen filtreye göre bir elaman döndürecek.
                return contex.Set<TEntity>().SingleOrDefault(filter);
            }
        }


        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext contex = new TContext())
            {
                //filter==lamda yani şartımızı göndereceğiz.
                //filter = null ise yani bir filtre yoksa contexti set et Product tablosunu.Değilse filtreye göre set et.
                return filter == null ? contex.Set<TEntity>().ToList() : contex.Set<TEntity>().Where(filter).ToList();
            }
        }


        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())//Using içine yazılan nesneler using bitince belelkten silinir.Buda kodu performanslı çalıştırır.
            {
                var updatedEntity = context.Entry(entity);// Veri kaynağına göndereceğim değeri ilişkilendir.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
