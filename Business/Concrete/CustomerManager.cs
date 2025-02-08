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
        IUserService _userService;  
        IUserOperationClaimService _userOperationClaimService; 


        public CustomerManager(ICustomerDal customerDal, 
            IUserService userService, 
            IUserOperationClaimService userOperationClaimService)
        {
            _customerDal = customerDal; 
            _userService = userService; 
            _userOperationClaimService = userOperationClaimService; 
        }

        [SecuredOperation("admin,customer.representative")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

            var userToCheck = _userService.GetByMail(customer.Email);

            if (userToCheck == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            var userExists = UserExists(customer.Email);

            if (!userExists.Success)
            {
                return new ErrorResult(userExists.Message);
            }

            int id = _userOperationClaimService.GetUserOperatinClaimId(customer.UserId); 

            if(id == 0)
            {
                return new ErrorResult(Messages.UserNotFound);  
            }
            else if (id != 4)
            {
                return new ErrorResult(Messages.userClaimIdNotUser);
            }


            var customerObject = new Customer
            {
                UserId = customer.UserId,
                CustomerName= customer.CustomerName,
                Email = customer.Email,
                Address = customer.Address, 
                PhoneNumber= customer.PhoneNumber,       
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


        [SecuredOperation("admin,customer.representative")]
        public IResult UserExists(string email)
        {
           if(GetByMail(email) != null)
           {
                return new ErrorResult(Messages.CustomerAlreadyExists);
           }

            return new SuccessResult();

        }

        [SecuredOperation("admin,customer.representative")]
        public Customer GetByMail(string email)
        {
            return _customerDal.Get(u => u.Email == email);

        }

    }
}
