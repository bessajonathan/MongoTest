using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace MongoTest.Entities
{
    public class User
    {
        public User(string name,DateTime birthDate,string[] roles)
        {
            Id = Guid.NewGuid();
            Name = name;
            BirthDate = birthDate;
            Roles = roles;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string[] Roles { get; set; }

        public JObject ToJson()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JObject.Parse(jsonString);
        }
    }

}
