using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        //IResult Add(User user);
        void Add(User user);
        User GetByMail(string email);
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();
    }
}
