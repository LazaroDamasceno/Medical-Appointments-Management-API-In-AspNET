using MedicalAppointmentsManagementAPI.Doctor;
using MedicalAppointmentsManagementAPI.Patient;
using MedicalAppointmentsManagementAPI.SystemUser;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsManagementAPI;

public class AppDbContext : DbContext
{

    public DbSet<SystemUserEntity> SystemUsers { get; set; }
    public DbSet<PatientEntity> Patients { get; set; }
    public DbSet<DoctorEntity> Doctors { get; set; }

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

        modelBuilder
            .Entity<DoctorEntity>()
            .HasIndex(e => e.LicenseNumber)
            .IsUnique();


        modelBuilder.Entity<SystemUserEntity>()
          .HasOne(e => e.Doctor)
          .WithOne(e => e.SystemUser)
          .HasForeignKey<DoctorEntity>(e => e.SystemUserId);
    }

}
