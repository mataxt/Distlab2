using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
/// <summary>
/// This is the context class of the project
/// </summary>
namespace Dist_Lab2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", false)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageUser> MessagesSent { get; set; }
        public DbSet<UserLogs> UserLogs { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserLogs>().HasKey(t => new {t.UserId, t.LoggedAt});
            modelBuilder.Entity<UserGroups>().HasKey(t => new {t.GroupName, t.UserId});
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}