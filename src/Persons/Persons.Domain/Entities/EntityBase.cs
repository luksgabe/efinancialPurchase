using System;
using System.Collections.Generic;
using System.Text;

namespace Persons.Domain.Entities
{
    public abstract class EntityBase
    {
        public virtual long Id { get; set; }
    }
}
