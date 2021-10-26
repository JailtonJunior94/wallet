using System;

namespace User.Domain.Dtos
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
