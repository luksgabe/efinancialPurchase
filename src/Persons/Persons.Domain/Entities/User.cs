﻿using EFinancialPurchase.AspNet.Common.Enums;
using Persons.Domain.Enums;

namespace Persons.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Roles Roles { get; set; }
        public Status Status { get; set; }

    }
}
