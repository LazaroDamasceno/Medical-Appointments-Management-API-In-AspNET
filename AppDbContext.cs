﻿using MedicalAppointmentsManagementAPI.Doctors;
using MedicalAppointmentsManagementAPI.MedicalAppointments;
using MedicalAppointmentsManagementAPI.Patients;
using MedicalAppointmentsManagementAPI.SystemUsers;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsManagementAPI;

public class AppDbContext : DbContext
{

    public DbSet<SystemUser> SystemUsers { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<MedicalAppointment> MedicalAppointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=mydb;Cache=Shared");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<SystemUser>()
            .HasIndex(e => e.Ssn)
            .IsUnique();

        modelBuilder
            .Entity<SystemUser>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder
            .Entity<Doctor>()
            .HasIndex(e => e.LicenseNumber)
            .IsUnique();

        modelBuilder
            .Entity<MedicalAppointment>()
            .HasOne(e => e.Patient)
            .WithMany(e => e.MedicalAppointments);
    }

}
