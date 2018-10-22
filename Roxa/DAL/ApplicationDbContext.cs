using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Roxa.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserTask> UsersTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(IoCContainer.Configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //many-to-many
            modelBuilder.Entity<UserTask>().HasKey(sc => new { sc.UserId, sc.TaskId });

            modelBuilder.Entity<UserTask>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserTask)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserTask>()
                .HasOne<Task>(sc => sc.Task)
                .WithMany(s => s.UserTask)
                .HasForeignKey(sc => sc.TaskId);
        }
    }
}
