using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SignalRServer.Models.DB;

namespace SignalRServer.Models
{
    public interface IToDoDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoleEmployee> Roles { get; set; }
        public DbSet<TaskEmployee> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

    public class ToDoDbContext : DbContext, IToDoDbContext
    {
        
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) 
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoleEmployee> Roles { get; set; }
        public DbSet<TaskEmployee> Tasks { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Employee>()
                .HasOne<RoleEmployee>(c => c.Role)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.IdRole);

            modelBuilder.Entity<Employee>()
                .HasMany<TaskEmployee>(c => c.Tasks)
                .WithOne(c => c.Employee)
                .HasForeignKey(c => c.IdEmployee);

            base.OnModelCreating(modelBuilder);
        }
    }
}
