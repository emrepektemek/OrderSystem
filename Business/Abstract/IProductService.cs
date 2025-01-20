using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max );
        IDataResult<List<ProductDetailDto>> GetProductsDetails();

        IDataResult<Product> GetById(int productId);

        // void Add(Product product); normalde boyleydi
        IResult Add(Product product); // artik void gordun yerlerde IResult yazacaksin cunku API yaziyoruz ve request sonucunda bir response dondurmemiz lazim

        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);  

    }
}
