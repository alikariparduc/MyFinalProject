using Business;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             
            ProductManager productManager = new ProductManager(new EfProductDal());
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(10,20))
            {
                Console.WriteLine(" Ürün Adı : " + " "+ product.ProductName+ " /// "+ " Ürün Fiyatı : " + " " +product.UnitPrice);
            }

        }
    }
}
