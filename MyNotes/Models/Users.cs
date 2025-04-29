using Microsoft.AspNetCore.Identity;

namespace MyNotes.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
