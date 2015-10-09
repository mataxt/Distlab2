using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dist_Lab2.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>()
                .HasMany(u => u.Receivers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("MessageId");
                    m.MapRightKey("Id");
                    m.ToTable("MessageUser");
                });


        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        }
    }
}