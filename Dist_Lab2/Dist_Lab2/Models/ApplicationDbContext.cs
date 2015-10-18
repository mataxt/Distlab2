using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dist_Lab2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", false)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<UserLogs> UserLogs { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>()
                .HasMany(u => u.Receivers)
                .WithMany(c => c.UserMessages)
                .Map(m =>
                {
                    m.MapLeftKey("MessageId");
                    m.MapRightKey("UserId");
                    m.ToTable("MessageUser");
                });

            modelBuilder.Entity<UserLogs>().HasKey(t => new {t.UserId, t.LoggedAt});
            modelBuilder.Entity<UserGroups>().HasKey(t => new {t.GroupName, t.UserId});
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}