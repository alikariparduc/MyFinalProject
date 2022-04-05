using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //NorthwindContext context = new NorthwindContext() bu şekildede newlenebilir using yerine ama performansı etkiler
            //IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())//Using içine yazılan nesneler using bitince belelkten silinir.Buda kodu performanslı çalıştırır.
            {
                var addetEntity = context.Entry(entity);// Veri kaynağına göndereceğim değeri ilişkilendir.
                addetEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())//Using içine yazılan nesneler using bitince belelkten silinir.Buda kodu performanslı çalıştırır.
            {
                var deletedEntity = context.Entry(entity);// Veri kaynağına göndereceğim değeri ilişkilendir.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext contex=new NorthwindContext())
            {
                //SingleOrDefault: anahtar sözcüğü ile dizi içerisinde bulunan elemanlardan
                //belirlenen koşula göre sadece bir tanesinin gelmesini sağlar
                //Dbden seçilen filtreye göre bir elaman döndürecek.
                return contex.Set<Product>().SingleOrDefault(filter);
            }
        }


        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext contex=new NorthwindContext())
            {
                //filter==lamda yani şartımızı göndereceğiz.
                //filter = null ise yani bir filtre yoksa contexti set et Product tablosunu.Değilse filtreye göre set et.
                return filter == null ? contex.Set<Product>().ToList() : contex.Set<Product>().Where(filter).ToList();
            }
        }


        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())//Using içine yazılan nesneler using bitince belelkten silinir.Buda kodu performanslı çalıştırır.
            {
                var updatedEntity = context.Entry(entity);// Veri kaynağına göndereceğim değeri ilişkilendir.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
