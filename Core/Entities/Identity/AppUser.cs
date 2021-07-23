using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
        public Type Type { get; set; }
    }

    public enum Type
    {
        [EnumMember(Value = "Admin")]
        Admin,
        [EnumMember(Value = "Customer")]
        Customer
    }
}
