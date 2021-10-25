using Newtonsoft.Json;
using System;

namespace User.Domain.Entities
{
    public class User
    {
        public User(string name, DateTime birthday, Account account)
        {
            Id = Guid.NewGuid();
            Name = name;
            Birthday = birthday;
            Account = account;
        }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public bool Status { get; private set; }
        public Account Account { get; private set; }

        public User ChangeStatus(bool status)
        {
            Status = status;
            return this;
        }
    }
}
