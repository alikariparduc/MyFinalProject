using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

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

        public List<Product> GetAll()
        {
            //İş kodları
            return _productDal.GetAll();

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice > min && p.UnitPrice < max);
        }
    }
}
