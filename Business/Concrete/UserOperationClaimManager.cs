using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager: IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal; 
                
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {         
            
            var userOperationClaimObject = new UserOperationClaim
            {        
                UserId = userOperationClaim.UserId,
                OperationClaimId = userOperationClaim.OperationClaimId, 
                Status = true,
                IsDeleted = false
            };

            _userOperationClaimDal.Add(userOperationClaimObject);

            return new SuccessResult(Messages.CreatedUserOperationClaim);   

            

        }
    }
}
