using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal // Burada yine IProductDal implemente etmemizin sebebi projede gelecekte EntityFramework yerine baska teknolojilere gecebiliriz Busniess katmaninda da IProductDal'a bagimli  
    {
        public List<ProductDetailDto> GetProductDetails()
        {

            // Linq ile JOIN yapabilmek icin tabikide veri tabanina baglanabilmek icin context nesnesi lazim 

            using (NorthwindContext context = new NorthwindContext())
            {

                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };

                return result.ToList();

            }


                
        }
    }
}
