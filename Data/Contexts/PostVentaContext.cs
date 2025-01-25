using System;
using System.Collections.Generic;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public partial class PostVentaContext : DbContext
{
    public PostVentaContext()
    {
    }

    public PostVentaContext(DbContextOptions<PostVentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Devolucione> Devoluciones { get; set; }

    public virtual DbSet<Garantia> Garantias { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Soporte> Soportes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Proyecto_dawa;User ID=sa;Password=12345678;Trusted_Connection=False;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Clientes__3213E83FDF7D5C6D");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.direccion).HasMaxLength(255);
            entity.Property(e => e.email).HasMaxLength(255);
            entity.Property(e => e.estado).HasMaxLength(20);
            entity.Property(e => e.nombre).HasMaxLength(255);
            entity.Property(e => e.telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Devolucione>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Devoluci__3213E83FC74680F7");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.cliente).HasMaxLength(255);
            entity.Property(e => e.estado).HasMaxLength(50);
            entity.Property(e => e.producto).HasMaxLength(255);
        });

        modelBuilder.Entity<Garantia>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Garantia__3213E83FB5C84D26");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.estado).HasMaxLength(50);
            entity.Property(e => e.fechaCompra).HasColumnType("datetime");
            entity.Property(e => e.fechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.numeroFactura).HasMaxLength(50);
            entity.Property(e => e.producto).HasMaxLength(255);
            entity.Property(e => e.ultimaActualizacion).HasColumnType("datetime");

            entity.HasOne(d => d.cliente).WithMany(p => p.Garantia)
                .HasForeignKey(d => d.cliente_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Garantias__clien__398D8EEE");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Producto__3213E83F51EB07D7");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.categoria).HasMaxLength(255);
            entity.Property(e => e.fechaAgregado).HasColumnType("datetime");
            entity.Property(e => e.nombre).HasMaxLength(255);
            entity.Property(e => e.precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Soporte>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Soporte__3213E83F3B23C536");

            entity.ToTable("Soporte");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.estado).HasMaxLength(50);
            entity.Property(e => e.producto).HasMaxLength(255);

            entity.HasOne(d => d.cliente).WithMany(p => p.Soportes)
                .HasForeignKey(d => d.cliente_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Soporte__cliente__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
