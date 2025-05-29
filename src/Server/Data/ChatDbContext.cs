using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class ChatDbContext : IdentityDbContext<User>
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Timestamp).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Messages)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(e => e.Timestamp);
            });
        }
    }
}