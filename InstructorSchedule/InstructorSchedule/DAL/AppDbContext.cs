using InstructorSchedule.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasctructrue.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Role> Roles{ get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot _configuration = builder.Build();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbContext"));
        }
    }
}
