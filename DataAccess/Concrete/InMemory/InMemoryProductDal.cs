using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;//Globl değişken olduğu için altçizgili oluşturduk.

        public InMemoryProductDal() //InMemoryProductDal newlendiğinde aşağıdaki gibi ürünlerin olduğu bir list oluşturacak.//Simulasyon
        {
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Bilgisayar",UnitPrice=8500,UnitsInStock=15 },
            new Product{ProductId=2,CategoryId=2,ProductName="Telefon",UnitPrice=7500,UnitsInStock=10 },
            new Product{ProductId=3,CategoryId=3,ProductName="Tablet",UnitPrice=3500,UnitsInStock=18 },
            new Product{ProductId=4,CategoryId=4,ProductName="Akıllı Saat",UnitPrice=1500,UnitsInStock=32 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // =>  LAMBDA 
            //Linq olmdan yazsaydık aşağıdaki gibi olcaktı.
            //Product productToDelete=null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //_produts listesini tektek kontrol eder.(SingleOrDefault) tek bir değer arar.
            //p adında bir geçici değer p.ProductId(_products.ProductId) eşittir silinmek için metoda göndeilen ProductId (product.ProductId)
            _products.Remove(productToDelete);//productToDelete ile gelen ProductId'ye göre _products lisstedeki ürünü siler..ss


        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllCategory(int categoryId)
        {
            //Verilen CategoryId'ye göre  ürünleri listeler.(Linq Where kullanımı)
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
