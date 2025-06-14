using Microsoft.AspNetCore.Identity;

namespace Chat.Server.API.Data.Models;

public class User : IdentityUser
{
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}