using Persons.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Domain.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
    }
}