using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Resource;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        ICategoryService _categoryService;  
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService; 
        }

        [SecuredOperation("admin,customer.representative")]

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            
            IResult result =  BusinessRules.Run(
                CheckIfCategoryExists(product.CategoryId), 
                CheckIfProductNameExists(product.ProductName));

            if (result != null)
            {
                return result;
            }

            var productObject = new Product
            {
                CategoryId = product.CategoryId,
                ProductName = product.ProductName, 
                Size = product.Size,    
                UnitPrice = product.UnitPrice,
                Description = product.Description,  
                CreatedUserId = 0,
                CreatedDate = DateTime.Now
            };


            _productDal.Add(productObject);

            return new SuccessResult(Messages.ProductAdded);   
        }

       
        public IDataResult<List<Product>> GetAll()
        {

            return new DataResult<List<Product>>(_productDal.GetAll(), true, Messages.ProductsListed);

        }


        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }



        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProductnameAlreadtExists);
            }

            return new SuccessResult();

        }

        private IResult CheckIfCategoryExists(int categoryId)
        {
            var result = _categoryService.GetByCategoryId(categoryId);

            if (result == null)
            {
                return new ErrorResult(Messages.CategoryNotExist);
            }

            return new SuccessResult();

        }



    }
}
