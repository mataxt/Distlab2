
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dist_Lab2.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public ApplicationDbContext() : base("DefaultConnection", false)
        {

        }

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

           modelBuilder.Entity<UserLogs>().HasKey(t => new { t.UserEmail, t.LoggedAt});
           modelBuilder.Entity<UserGroups>().HasKey(t => new { t.GroupId, t.GroupMembers});
        }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<UserLogs> UserLogs { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
    }
}