using System;
using System.Collections.Generic;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detalle_Orden> DetalleOrdenes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Ordenes> Ordenes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=ProySoft;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detalle_Orden>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Detalle_Orden");

            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Orden).WithMany()
                .HasForeignKey(d => d.OrdenId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Detalle_O__Orden__412EB0B6");

            entity.HasOne(d => d.Producto).WithMany()
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Detalle_Orden_Productos_ProductoID_fk");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("Factura_pk");

            entity.ToTable("Factura");

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Factura");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Monto_Total");
            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");

            entity.HasOne(d => d.Orden).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("Factura_Ordenes_OrdenID_fk");
        });

        modelBuilder.Entity<Ordenes>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("OrdenID");

            entity.Property(e => e.OrdenId).HasColumnName("OrdenID");
            entity.Property(e => e.FechaOrden)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Orden");
            entity.Property(e => e.OrdenStatus)
                .HasMaxLength(1)
                .HasColumnName("Orden_Status");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("ProductoID");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.ProductoImagen)
                .HasMaxLength(255)
                .HasColumnName("Producto_Imagen");
            entity.Property(e => e.ProductoNombre)
                .HasMaxLength(100)
                .HasColumnName("Producto_Nombre");
            entity.Property(e => e.ProductoPrecio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Producto_Precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
