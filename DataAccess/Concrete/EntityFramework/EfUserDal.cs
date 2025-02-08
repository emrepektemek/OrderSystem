using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, OrderSystemContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new OrderSystemContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserOperationAssignmentDto> GetUsers()
        {
            using (var context = new OrderSystemContext())
            {

                var result = from u in context.Users
                             join uoc in context.UserOperationClaims
                             on u.Id equals uoc.UserId into userClaims
                             from uoc in userClaims.DefaultIfEmpty()
                             join oc in context.OperationClaims
                             on uoc.OperationClaimId equals oc.Id into claims
                             from oc in claims.DefaultIfEmpty()
                             select new UserOperationAssignmentDto
                             {
                                 Id = uoc.Id,
                                 UserId = u.Id,
                                 OperationClaimId = oc.Id, 
                                 OperationClaimName = oc.Name,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName, 
                                 Email = u.Email,
                                 PhoneNumber = u.PhoneNumber,
                                 IsDeleted = uoc.IsDeleted
                             };

                return result.ToList();

            }
        }

        public List<User> GetUsersForCustomer()
        {
            using (var context = new OrderSystemContext())
            {
                var result = from u in context.Users
                             join uc in context.UserOperationClaims on u.Id equals uc.UserId
                             where uc.OperationClaimId == 4
                             && !context.Customers.Any(c => c.UserId == u.Id)
                             select new User
                             {
                                 Id = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 PhoneNumber = u.PhoneNumber,
                                 Gender = u.Gender
                             };

                return result.ToList();
            }
        }

        public User Add(User user)
        {
            using (OrderSystemContext context = new OrderSystemContext())
            {
                var addedEntity = context.Entry(user);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }

            return user;
        }

       
    }
}
