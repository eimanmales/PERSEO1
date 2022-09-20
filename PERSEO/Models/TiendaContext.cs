using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PERSEO.Models
{
    public partial class TiendaContext : DbContext
    {
        public TiendaContext()
        {
        }

        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Locale> Locales { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("server=DESKTOP-UQ95FH1; database=Tienda; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PK__cliente__C035B8DC3F5991D4");

                entity.ToTable("cliente");

                entity.Property(e => e.Dni)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("DNI")
                    .IsFixedLength();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.Factura1)
                    .HasName("PK__factura__83BC389BD450FEC2");

                entity.ToTable("factura");

                entity.Property(e => e.Factura1).HasColumnName("Factura");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Vendedor).HasColumnName("vendedor");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto1");

                entity.HasOne(d => d.VendedorNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Vendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vendedor1");
            });

            modelBuilder.Entity<Locale>(entity =>
            {
                entity.HasKey(e => e.Movimiento)
                    .HasName("PK__locales__E3AF250C80384123");

                entity.ToTable("locales");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NLocal).HasColumnName("N_Local");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.Locales)
                    .HasForeignKey(d => d.CodigoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productos");

                entity.HasOne(d => d.VendedorNavigation)
                    .WithMany(p => p.Locales)
                    .HasForeignKey(d => d.Vendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vendedor");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__producto__06370DADC5C21761");

                entity.ToTable("productos");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(7, 3)");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.CodigoVendedor)
                    .HasName("PK__vendedor__2255F69CDA438078");

                entity.ToTable("vendedor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("DNI")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
