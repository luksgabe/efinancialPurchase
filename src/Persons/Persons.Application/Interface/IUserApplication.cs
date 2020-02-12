using Persons.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persons.Application.Interface
{
    public interface IUserApplication
    {
        Task<IEnumerable<UserViewModel>> GetAll();
    }
}
