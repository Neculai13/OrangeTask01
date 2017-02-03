using System.Data.Entity;
using Domain.Entities;

namespace Domain.Repository
{
    public class SoftTehnicaDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DbSet<User> Users { get; set; }
    }
}