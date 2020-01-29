using DotNetCore.Objects;
using EFinancialPurchase.AspNet.Common.CommandResult;
using Persons.Application.ViewModels;
using System.Threading.Tasks;

namespace Persons.Application.Interface
{
    public interface IAccountApplication
    {
        Task<AppResult<LoginViewModel>> Login(LoginViewModel login);
    }
}
