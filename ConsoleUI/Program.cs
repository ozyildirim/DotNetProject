﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.inMemory;
using System;

namespace ConsoleUI
{
    //SOLID
    //O -> Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //IoC
            //CategoryTest();
        }

        //private static void CategoryTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    foreach (var category in categoryManager.GetAll())
        //    {
        //        Console.WriteLine(category.CategoryId + " -> " + category.CategoryName);
        //    }
        //}

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetAll();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}