using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        public void Add(Product entity);
        List<Product> GetAllByCategoryId(int id);//Kategoriye göre ürünleri listele.
        List<Product> GetByUnitPrice(decimal min, decimal max);//Fiyat aralığına göre listeleme filtre operasyonu
        
        
    }
}
