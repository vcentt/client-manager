using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public partial class ClientContext : DbContext
{
    public ClientContext()
    {
    }

    public ClientContext(DbContextOptions<ClientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.ClientId);

            entity.ToTable("Address");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("ClientID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.StreetAddress).HasMaxLength(100);
            entity.Property(e => e.Zip).HasColumnName("ZIP");

            // entity.HasOne(d => d.Client).WithOne(p => p.Address)
            //     .HasForeignKey<Address>(d => d.ClientId)
            //     .HasConstraintName("FK__Address__ClientI__70DDC3D8")
            //     .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A04B23ECE3D");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ClientId);

            entity.ToTable("Profile");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("ClientID");
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.MaritalStatus).HasMaxLength(20);

            // entity.HasOne(d => d.Client).WithOne(p => p.Profile)
            //     .HasForeignKey<Profile>(d => d.ClientId)
            //     .HasConstraintName("FK__Profile__ClientI__6EF57B66")
            //     .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
