namespace Persons.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public int LastName { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
