using System;
using Newtonsoft.Json;

namespace User.Domain.Entities
{
    public class Users
    {
        public Users(string name, DateTime birthday)
        {
            Id = Guid.NewGuid();
            Name = name;
            Birthday = birthday;
        }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; private set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "birthday")]
        public DateTime Birthday { get; private set; }

        [JsonProperty(PropertyName = "status")]
        public bool Status { get; private set; }

        [JsonProperty(PropertyName = "account")]
        public Accounts Account { get; private set; }

        public Users ChangeStatus(bool status)
        {
            Status = status;
            return this;
        }

        public Users AddAccount(Accounts account)
        {
            Account = account;
            return this;
        }
    }
}
