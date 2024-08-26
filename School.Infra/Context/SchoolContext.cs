using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School.Model.Entities;
using School.Model.Infra.Mappings;

namespace School.Model.Infra.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetSection("sqlserver_school_database")["connectiostring"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new EnrollmentMapping());
            modelBuilder.ApplyConfiguration(new StudentMapping());
            modelBuilder.ApplyConfiguration(new TeacherMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
