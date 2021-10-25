using System;

namespace User.Domain.Entities
{
    public class Account
    {
        public Account(decimal amount)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Status = true;
        }

        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public bool Status { get; private set; }

        public decimal GetBalance()
        {
            return Amount;
        }
    }
}
