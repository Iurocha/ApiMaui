using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cliente.Core.Domain.Auth.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
