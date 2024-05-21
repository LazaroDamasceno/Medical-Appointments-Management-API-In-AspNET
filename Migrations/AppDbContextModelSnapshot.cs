﻿// <auto-generated />
using System;
using MedicalAppointmentsManagementAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalAppointmentsManagementAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.Doctors.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HiringDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SystemUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("TerminationDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LicenseNumber")
                        .IsUnique();

                    b.HasIndex("SystemUserId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.MedicalAppointments.MedicalAppointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CancelledDateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FinishingDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalNote")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ScheduledDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalAppointments");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.Patients.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SystemUserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SystemUserId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.SystemUsers.SystemUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ssn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Ssn")
                        .IsUnique();

                    b.ToTable("SystemUsers");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.Doctors.Doctor", b =>
                {
                    b.HasOne("MedicalAppointmentsManagementAPI.SystemUsers.SystemUser", "SystemUser")
                        .WithOne("Doctor")
                        .HasForeignKey("MedicalAppointmentsManagementAPI.Doctors.Doctor", "SystemUserId");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.MedicalAppointments.MedicalAppointment", b =>
                {
                    b.HasOne("MedicalAppointmentsManagementAPI.Doctors.Doctor", "Doctor")
                        .WithMany("MedicalAppointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("MedicalAppointmentsManagementAPI.Patients.Patient", "Patient")
                        .WithMany("MedicalAppointments")
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.Patients.Patient", b =>
                {
                    b.HasOne("MedicalAppointmentsManagementAPI.SystemUsers.SystemUser", "SystemUser")
                        .WithOne("Patient")
                        .HasForeignKey("MedicalAppointmentsManagementAPI.Patients.Patient", "SystemUserId");

                    b.Navigation("SystemUser");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.Doctors.Doctor", b =>
                {
                    b.Navigation("MedicalAppointments");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.Patients.Patient", b =>
                {
                    b.Navigation("MedicalAppointments");
                });

            modelBuilder.Entity("MedicalAppointmentsManagementAPI.SystemUsers.SystemUser", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
