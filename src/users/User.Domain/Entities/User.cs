using System;

namespace User.Domain.Entities
{
    public class User
    {
        public User(string name, DateTime birthday)
        {
            Id = Guid.NewGuid();
            Amount = 100;
            Name = name;
            Birthday = birthday;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public decimal Amount { get; private set; }
        public bool Status { get; private set; }

        public User ChangeStatus(bool status)
        {
            Status = status;
            return this;
        }

        public decimal GetBalance()
        {
            return Amount;
        }
    }
}
