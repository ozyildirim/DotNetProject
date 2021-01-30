﻿using Business.Concrete;
using DataAccess.Concrete.inMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new inMemoryProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
