using DoctorsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsApp.DB
{
    public class DoctorsDbContext : DbContext
    {
        public DoctorsDbContext(DbContextOptions<DoctorsDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Doctor> Doctors { get; set; }
    }
}
