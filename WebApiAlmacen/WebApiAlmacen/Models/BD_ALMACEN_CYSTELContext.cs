using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiAlmacen.Models
{
    public partial class BD_ALMACEN_CYSTELContext : DbContext
    {
        public BD_ALMACEN_CYSTELContext()
        {
        }

        public BD_ALMACEN_CYSTELContext(DbContextOptions<BD_ALMACEN_CYSTELContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESTROYERPC\\SQLEXPRESS ;database=BD_ALMACEN_CYSTEL ;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK__PRODUCTO__ABDAF2B4250E34F5");

                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.Idproducto)
                    .ValueGeneratedNever()
                    .HasColumnName("IDProducto");

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.HasKey(e => e.Idtransaccion)
                    .HasName("PK__TRANSACC__2DABE47E661CFA37");

                entity.ToTable("TRANSACCIONES");

                entity.Property(e => e.Idtransaccion)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTransaccion");

                entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");

                entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TipoTransaccion).HasMaxLength(10);

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("FK__TRANSACCI__IDPro__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
