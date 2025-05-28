using Microsoft.AspNetCore.Identity;

namespace Server.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}