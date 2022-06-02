using Business;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Business.Concrete;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ///OrderTest();

            //CategoryTest();

            getclaimsTest();

        }

        private static void getclaimsTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var resultUser = userManager.GetUser(8);
            var result = userManager.GetClaims(resultUser);
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    var result = productManager.GetProductDetailDtos();
        //    if (result.Success==true)
        //    {
        //        foreach (var product in result.Data)
        //        {
        //            Console.WriteLine(product.ProductId + "  - " + product.ProductName + " - " + product.CategoryName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }

        //}

        //private static void CategoryTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    foreach (var category in categoryManager.GetAll())
        //    {
        //        Console.WriteLine(category.CategoryId +"  -  "+category.CategoryName);
        //    }
        //}

        private static void OrderTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var order in orderManager.GetAll())
            {
                Console.WriteLine(" Order Tarihi  : " + " " + order.OrderDate + " /// " + " Müşteri ID: " + " " + order.CustomerId);
            }
        }
    }
}
