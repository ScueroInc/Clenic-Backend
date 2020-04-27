using System;
using MyE.Entities;
using Microsoft.EntityFrameworkCore;


namespace MyE.Data
{
    public partial class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Ejemplar> Ejemplar { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Fabricante> Fabricante { get; set; }
        public virtual DbSet<Lugar> Lugar { get; set; }
        public virtual DbSet<LugarCliente> LugarCliente { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenDetalle> OrdenDetalle { get; set; }
        public virtual DbSet<OrdenServicio> OrdenServicio { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=tb2-mye-database.database.windows.net;Initial Catalog=MyE_Dev;Persist Security Info=True;User ID=DB-Admin;Password=6532519jA");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.ClienteId).ValueGeneratedOnAdd();

                entity.Property(e => e.Nsector)
                    .IsRequired()
                    .HasColumnName("NSector")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClienteNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cliente_Persona");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamento");

                entity.Property(e => e.DepartamentoId)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Ndepartamento)
                    .IsRequired()
                    .HasColumnName("NDepartamento")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.Ubigeo)
                    .HasName("distrito_pk");

                entity.ToTable("distrito");

                entity.Property(e => e.Ubigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DepartamentoId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DistritoId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Ndistrito)
                    .IsRequired()
                    .HasColumnName("NDistrito")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinciaId)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Distrito)
                    .HasForeignKey(d => new { d.ProvinciaId, d.DepartamentoId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Distrito_Provincia");
            });

            modelBuilder.Entity<Ejemplar>(entity =>
            {
                entity.ToTable("ejemplar");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Ejemplar)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ejemplar_Equipo");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.Property(e => e.EmpleadoId).ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tdireccion)
                    .IsRequired()
                    .HasColumnName("TDireccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmpleadoNavigation)
                    .WithOne(p => p.Empleado)
                    .HasForeignKey<Empleado>(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Empleado_Persona");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("equipo");

                entity.Property(e => e.CodBarra)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Modelo)
                    .WithMany(p => p.Equipo)
                    .HasForeignKey(d => d.ModeloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Equipo_Modelo");
            });

            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.ToTable("fabricante");

                entity.Property(e => e.Nfabricante)
                    .IsRequired()
                    .HasColumnName("NFabricante")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lugar>(entity =>
            {
                entity.ToTable("lugar");

                entity.Property(e => e.LugarReferencia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tdireccion)
                    .IsRequired()
                    .HasColumnName("TDireccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ubigeo)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.UbigeoNavigation)
                    .WithMany(p => p.Lugar)
                    .HasForeignKey(d => d.Ubigeo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lugar_Distrito");
            });

            modelBuilder.Entity<LugarCliente>(entity =>
            {
                entity.ToTable("lugar_cliente");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSede)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.LugarCliente)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LugarCliente_Cliente");

                entity.HasOne(d => d.Lugar)
                    .WithMany(p => p.LugarCliente)
                    .HasForeignKey(d => d.LugarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Lugar_Personas_Lugar");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("modelo");

                entity.Property(e => e.Nmodelo)
                    .IsRequired()
                    .HasColumnName("NModelo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EquipoNavigation)
                    .WithMany(p => p.Modelo)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Modelo_Marca");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("orden");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEjecucion).HasColumnType("date");

                entity.Property(e => e.FechaGeneracion).HasColumnType("date");

                entity.Property(e => e.LugarPersonasId).HasColumnName("Lugar_PersonasId");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orden_empleado");

                entity.HasOne(d => d.LugarPersonas)
                    .WithMany(p => p.Orden)
                    .HasForeignKey(d => d.LugarPersonasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orden_Lugar_Personas");
            });

            modelBuilder.Entity<OrdenDetalle>(entity =>
            {
                entity.ToTable("orden_detalle");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ejemplar)
                    .WithMany(p => p.OrdenDetalle)
                    .HasForeignKey(d => d.EjemplarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orden_Detalle_Ejemplar");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.OrdenDetalle)
                    .HasForeignKey(d => d.OrdenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orden_Detalle_Orden");
            });

            modelBuilder.Entity<OrdenServicio>(entity =>
            {
                entity.ToTable("orden_servicio");

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.OrdenDetalle)
                    .WithMany(p => p.OrdenServicio)
                    .HasForeignKey(d => d.OrdenDetalleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrdenServicio_OrdenDetalle");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.OrdenServicio)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrdenServicio_Servicio");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Npersona)
                    .IsRequired()
                    .HasColumnName("NPersona")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => new { e.ProvinciaId, e.DepartamentoId })
                    .HasName("provincia_pk");

                entity.ToTable("provincia");

                entity.Property(e => e.ProvinciaId)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DepartamentoId)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Nprovincia)
                    .IsRequired()
                    .HasColumnName("NProvincia")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_60_Departamento");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.ToTable("reporte");

                entity.Property(e => e.Asunto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAtencion).HasColumnType("date");

                entity.Property(e => e.FechaEjecucion).HasColumnType("date");

                entity.Property(e => e.FechaGeneracion).HasColumnType("date");

                entity.Property(e => e.Observacion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrdenServicio)
                    .WithMany(p => p.Reporte)
                    .HasForeignKey(d => d.OrdenServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reporte_OrdenServicio");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("servicio");

                entity.Property(e => e.Nservicio)
                    .IsRequired()
                    .HasColumnName("NServicio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Perfil)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Psw)
                    .IsRequired()
                    .HasColumnName("psw")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_31_Persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
