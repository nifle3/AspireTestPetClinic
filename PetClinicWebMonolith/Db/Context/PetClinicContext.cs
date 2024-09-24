using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PetClinicWebMonolith.Db.Models;

namespace PetClinicWebMonolith.Db.Context;

public class PetClinicContext: DbContext
{
    public PetClinicContext()
    {

    }

    public PetClinicContext(DbContextOptions<PetClinicContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { set; get; }

    public DbSet<Doctor> Doctors { set; get; }

    public DbSet<Pet> Pets { set; get; }

    public DbSet<Reception> Receptions { set; get; }

    public DbSet<Service> Services { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Client>(entity =>
            {
                entity.ToTable("Clients");
                entity.HasKey(c => c.Id);
                entity.HasIndex(c => c.Email).IsUnique();
                entity.HasIndex(c => c.PhoneNumber).IsUnique();

                entity.Property(c => c.Email).HasMaxLength(255).IsUnicode().IsRequired();
                entity.Property(c => c.Password).HasMaxLength(255).IsUnicode().IsRequired();
                entity.Property(c => c.PhoneNumber).HasMaxLength(20).IsUnicode(false).IsRequired();
                entity.Property(c => c.LastName).HasMaxLength(255).IsUnicode().IsRequired();
                entity.Property(c => c.FirstName).HasMaxLength(255).IsUnicode().IsRequired();
            });

        modelBuilder
            .Entity<Pet>(entity =>
            {
                entity.ToTable("Pets");
                entity.HasKey(c => c.Id);

                entity.HasIndex(c => c.Passport).IsUnique();

                entity.HasOne(c => c.Client).WithMany(c => c.Pets).HasForeignKey(c => c.ClientId).OnDelete(DeleteBehavior.Cascade);

                entity.Property(c => c.PhotoUrl).HasMaxLength(255).IsUnicode().IsRequired(false);
                entity.Property(c => c.Sex).HasMaxLength(255).IsUnicode().IsRequired();
                entity.Property(c => c.Name).HasMaxLength(255).IsUnicode().IsRequired();
                entity.Property(c => c.Type).HasMaxLength(255).IsUnicode().IsRequired();
                entity.Property(c => c.Breed).HasMaxLength(255).IsUnicode().IsRequired();
            });

        modelBuilder
           .Entity<Doctor>(entity =>
           {
               entity.ToTable("Doctors");

               entity.Property(c => c.PhotoUrl).HasMaxLength(255).IsUnicode().IsRequired(false);
               entity.Property(c => c.FirstName).HasMaxLength(255).IsUnicode().IsRequired();
               entity.Property(c => c.LastName).HasMaxLength(255).IsUnicode().IsRequired();
               entity.Property(c => c.Specialization).HasMaxLength(255).IsUnicode().IsRequired();
           });

        modelBuilder
           .Entity<Reception>(entity =>
           {
               entity.ToTable("Receptions");

               entity.HasOne(c => c.Pet).WithMany(c => c.Receptions).HasForeignKey(c => c.PetId).OnDelete(DeleteBehavior.Cascade);
               entity.HasOne(c => c.Doctor).WithMany(c => c.Receptions).HasForeignKey(c => c.DoctorId).OnDelete(DeleteBehavior.Cascade);
               entity.HasOne(c => c.Service).WithMany(c => c.Receptions).HasForeignKey(c => c.ServiceId).OnDelete(DeleteBehavior.Cascade);
           });

        modelBuilder
           .Entity<Service>(entity =>
           {
               entity.ToTable("Services");
               entity.Property(c => c.Name).HasMaxLength(255).IsUnicode().IsRequired(false);
               entity.Property(c => c.Description).HasMaxLength(255).IsUnicode().IsRequired();

           });

        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Services)
            .WithMany(s => s.Doctors)
            .UsingEntity(j => j.ToTable("DoctorServices"));

        base.OnModelCreating(modelBuilder);
    }
}
