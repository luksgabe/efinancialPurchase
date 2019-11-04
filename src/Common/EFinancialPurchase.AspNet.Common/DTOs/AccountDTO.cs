using System;
using System.Collections.Generic;
using System.Text;

namespace EFinancialPurchase.AspNet.Common.DTOs
{
    public class AccountDTO : BaseDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
        public string Token { get; set; }
    }
}
