using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<UserModel> UsersModel { get; set; }
        public DbSet<ToDoAudit> ToDoAudits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoAudit>()
                .Property(b => b.Field)
                .IsRequired(false);//optinal case
            modelBuilder.Entity<ToDoAudit>()
                .Property(b => b.NewValue)
                .IsRequired(false);
            modelBuilder.Entity<ToDoAudit>()
                .Property(b => b.OldValue)
                .IsRequired(false);
            modelBuilder
                .Entity<ToDoAudit>()
                .HasOne(e => e.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
