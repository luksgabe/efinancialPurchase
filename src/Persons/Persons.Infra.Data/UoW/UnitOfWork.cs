﻿using Persons.Domain.Interfaces;
using Persons.Domain.Validations;
using Persons.Domain.Validations.Rules;
using Persons.Infra.Data.Context;
using Persons.Infra.Data.Repositories;

namespace Persons.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository _userRepository;
        private IUserLoginValidation _userLoginValidate;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository userRepository
        {
            get
            {
                _userRepository = _userRepository ?? new UserRepository(_context);
                return _userRepository;
            }
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #region  Implementations Validation

        public IUserLoginValidation userLoginValidate
        {
            get
            {
                 _userLoginValidate = _userLoginValidate ?? new UserLoginValidation(new UserRule(userRepository));
                return _userLoginValidate;
            }
        }

        #endregion

    }
}
