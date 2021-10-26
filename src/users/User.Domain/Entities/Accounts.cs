using System;
using Newtonsoft.Json;

namespace User.Domain.Entities
{
    public class Accounts
    {
        public Accounts(decimal amount)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Status = true;
        }

        [JsonProperty(PropertyName = "accountID")]
        public Guid Id { get; private set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; private set; }

        [JsonProperty(PropertyName = "status")]
        public bool Status { get; private set; }

        public decimal GetBalance()
        {
            return Amount;
        }
    }
}
