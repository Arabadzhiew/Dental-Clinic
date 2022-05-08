using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dental_Clinic
{
    public partial class dentalclinicContext : DbContext
    {
        public dentalclinicContext()
        {
        }

        public dentalclinicContext(DbContextOptions<dentalclinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Dentist> Dentists { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3307;user=root;password=password;database=dentalclinic", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment");

                entity.HasIndex(e => e.DentistId, "fk_appointment_dentist_id");

                entity.HasIndex(e => e.PatientId, "fk_appointment_patient_id");

                entity.HasIndex(e => e.ScheduledFor, "unique_appointment_schedule")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DentistId).HasColumnName("dentist_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.ScheduledFor)
                    .HasColumnType("datetime")
                    .HasColumnName("scheduled_for");

                entity.HasOne(d => d.Dentist)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DentistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_appointment_dentist_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_appointment_patient_id");
            });

            modelBuilder.Entity<Dentist>(entity =>
            {
                entity.ToTable("dentist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.HasIndex(e => e.DentistId, "fk_patient_dentist_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.BirthDate).HasColumnName("birth_date");

                entity.Property(e => e.DentistId).HasColumnName("dentist_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .HasColumnName("last_name");

                entity.HasOne(d => d.Dentist)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DentistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_patient_dentist_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
