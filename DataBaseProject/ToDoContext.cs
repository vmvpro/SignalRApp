using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataBaseProject
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "data source = " + Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"Data\ToDoDB.db"));

            optionsBuilder.UseSqlite(
                //Configuration["Data:ConnectionString"],
                connectionString,
                opts =>
                {
                    opts.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);

                });

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TaskEmployee> Tasks { get; set; }

        public DbSet<RoleEmployee> Roles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //public IDbConnection Connection { get; }
        //DatabaseFacade Database { get; }

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.SId, sc.CId });

            modelBuilder.Entity<Employee>()
                .HasOne(c => c.Role)
                .WithMany(c => c.Employees)
                .HasForeignKey(c => c.IdRole);

            //modelBuilder.Entity<Employee>()
            //    .HasMany<TaskEmployee>(c => c.Tasks)
            //    .WithOne(c => c.)
            //    .HasForeignKey(c => c.RoleId);

            //modelBuilder.Entity<RoleEmployee>()
            //    .HasMany<Employee>(c => c.Employees)
            //    .WithOne(c => c.Role)
            //    .HasForeignKey(c => c.EmployeeId);

            modelBuilder.Entity<TaskEmployee>()
                .HasOne(c => c.Employee)
                .WithMany(c => c.Tasks)
                .HasForeignKey(c => c.IdEmployee);

            base.OnModelCreating(modelBuilder);
        }


        //protected override void Seed_(GameApplication.DAL.GameContext context)
        //{
        //    var games = new List<Game>
        //    {
        //        new Game{Name="Super Mario Bros"},
        //        new Game{Name="Super Mario 64"},
        //        new Game{Name="Super Mario Galaxy"}
        //    };
        //    games.ForEach(e => context.Games.AddOrUpdate(p => p.Name, e));
        //    context.SaveChanges();
        //}
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
