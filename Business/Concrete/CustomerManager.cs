using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
                _customerDal = customerDal; 
        }

        [SecuredOperation("admin,customer.representative")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

            var customerObject = new Customer
            {
                Id = customer.Id,
                CustomerName= customer.CustomerName,
                Address= customer.Address, 
                PhoneNumber= customer.PhoneNumber,
                Email= customer.Email,  
                CreatedUserId = customer.CreatedUserId,
                CreatedDate= DateTime.Now, 
            };

            _customerDal.Add(customerObject);
 
            return new SuccessResult(Messages.CreatedCustomer);
        }

        public IDataResult<List<Customer>>  GetAll()
        {

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());

        }
    }
}
