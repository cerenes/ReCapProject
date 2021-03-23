using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        /*public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }
        */
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }
        public IDataResult<User> GetById(int UserId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == UserId));
        }

    }
}
