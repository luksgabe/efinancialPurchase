using EFinancialPurchase.AspNet.Common.Enums;
using Persons.Domain.Enums;

namespace Persons.Application.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Roles Roles { get; set; }
        public Status Status { get; set; }
    }
}
