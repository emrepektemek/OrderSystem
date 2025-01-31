using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<UserOperationAssignmentDto>> GetUsers();
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        
    }
}
