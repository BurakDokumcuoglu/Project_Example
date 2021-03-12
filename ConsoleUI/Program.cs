using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EnityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();

            // CategoryTest();

            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            var liste = productManager.GetProductDetails();
            Console.WriteLine(liste.Message);
            foreach (var item in liste.Data)
            {
                Console.WriteLine("Ürün adı : "+item.ProductName+"   ----   Kategorisi : "+item.CategoryName);
            }
            

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var liste2 = categoryManager.GetAll().Data;
            foreach (var item in liste2)
            {
                Console.WriteLine("Kategori adı : " + item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
            var liste = productManager.GetByUnitPrice(1, 10);
            foreach (var item in liste.Data)
            {
                Console.WriteLine(item.ProductName);
                Console.WriteLine("Fiyatı : " + item.UnitPrice);
                Console.WriteLine();

            }
        }
    }
}
