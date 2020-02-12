using EFinancialPurchase.AspNet.Common.Enums;

namespace Persons.Domain.Entities
{
    public class Account : EntityBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public long IdUser { get; set; }
        public virtual User User { get; set; }
        public Status Status { get; set; }
    }
}
