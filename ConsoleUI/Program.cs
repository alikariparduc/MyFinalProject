﻿using Business;
using System;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

        }
    }
}
