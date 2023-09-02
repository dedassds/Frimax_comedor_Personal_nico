using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrimaxComedor.Models
{
    public partial class MenuContext : DbContext
    {
        public MenuContext()
        {
        }

        public MenuContext(DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dia> Dias { get; set; } = null!;
        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<MenuLune> MenuLunes { get; set; } = null!;
        public virtual DbSet<Registromenu> Registromenus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Menu;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dia>(entity =>
            {
                entity.Property(e => e.DiaId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__MenuItem__727E838B919E3042");

                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuLune>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Agua)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Caldosa)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Guarnicion1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Guarnicion2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Guarnicion3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Platillo1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Platillo2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Postre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.MenuLune)
                    .HasForeignKey<MenuLune>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MenuLunes__ID__25518C17");
            });

            modelBuilder.Entity<Registromenu>(entity =>
            {
                entity.HasKey(e => e.Idmenu)
                    .HasName("PK__Registro__E01BB23852118989");

                entity.Property(e => e.Idmenu)
                    .ValueGeneratedNever()
                    .HasColumnName("IDMENU");

                entity.Property(e => e.Bebida)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BEBIDA");

                entity.Property(e => e.Caldosa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CALDOSA");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPLEMENTO");

                entity.Property(e => e.Dia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIA");

                entity.Property(e => e.GguarnicionUnos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GGUARNICION_UNOS");

                entity.Property(e => e.GuarnicionDos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GUARNICION_DOS");

                entity.Property(e => e.GuarnicionTres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GUARNICION_TRES");

                entity.Property(e => e.PlatilloDos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PLATILLO_DOS");

                entity.Property(e => e.PlatilloUno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PLATILLO_UNO");

                entity.Property(e => e.Postre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("POSTRE");

                entity.Property(e => e.Semana).HasColumnName("SEMANA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
