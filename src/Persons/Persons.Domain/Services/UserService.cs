using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFinancialPurchase.AspNet.Common.Interfaces;
using Persons.Domain.Entities;
using Persons.Domain.Interfaces;

namespace Persons.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IValidatorApp<User> _validator;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _unitOfWork.userRepository.GetAllAsync();
            return users.ToList();
        }
    }
}
