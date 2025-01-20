using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
        {
            ProductTest();

            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }

            Console.WriteLine();

            Category categorySingle = categoryManager.GetById(3).Data;

            Console.WriteLine(categorySingle.CategoryName);
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductsDetails();

            if (result.Success)
            {
                foreach (var product in result.Data) // Categories ile Products tablosunun JOIN ornegi
                {
                    Console.WriteLine(product.ProductId + " / " + product.ProductName + " / " + product.CategoryName + " / " + product.UnitsInStock);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}