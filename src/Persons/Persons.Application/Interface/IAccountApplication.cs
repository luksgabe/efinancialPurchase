using Persons.Application.ViewModels;
using System.Threading.Tasks;

namespace Persons.Application.Interface
{
    public interface IAccountApplication
    {
        Task<string> Login(LoginViewModel login);
    }
}
