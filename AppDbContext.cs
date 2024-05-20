using MedicalAppointmentsManagementAPI.Patient;
using MedicalAppointmentsManagementAPI.SystemUser;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsManagementAPI;

public class AppDbContext : DbContext
{

    public DbSet<SystemUserEntity> SystemUsers { get; set; }
    public DbSet<PatientEntity> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=mydb;Cache=Shared");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<SystemUserEntity>()
            .HasIndex(e => e.Ssn)
            .IsUnique();

        modelBuilder
            .Entity<SystemUserEntity>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<SystemUserEntity>()
          .HasOne(e => e.Patient)
          .WithOne(e => e.SystemUser)
          .HasForeignKey<PatientEntity>(e => e.SystemUserId);
    }

}
