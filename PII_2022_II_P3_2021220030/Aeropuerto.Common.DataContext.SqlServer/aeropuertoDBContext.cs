using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Packt.Shared
{
    public partial class aeropuertoDBContext : DbContext
    {
        public aeropuertoDBContext()
        {
        }

        public aeropuertoDBContext(DbContextOptions<aeropuertoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avione> Aviones { get; set; } = null!;
        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Reservacione> Reservaciones { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vuelo> Vuelos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:aeropuerto-server.database.windows.net,1433;Initial Catalog=aeropuertoDB;Persist Security Info=False;User ID=Administrador;Password=zFD@wvF76rQ9NaS;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservacione>(entity =>
            {
                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVACIONES_CLIENTES");

                entity.HasOne(d => d.IdVueloNavigation)
                    .WithMany(p => p.Reservaciones)
                    .HasForeignKey(d => d.IdVuelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVACIONES_VUELOS");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIOS_CARGOS");
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
            entity.HasOne(d => d.IdAvionNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.IdAvion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VUELOS_AVIONES");

            entity.HasOne(d => d.IdPilotoNavigation)
                    .WithMany(p => p.Vuelos)
                    .HasForeignKey(d => d.IdPiloto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VUELOS_USUARIOS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
