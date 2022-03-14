using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace gb_shop_api.Models.Data
{
    public partial class gb_shopContext : DbContext
    {
        public gb_shopContext()
        {
        }

        public gb_shopContext(DbContextOptions<gb_shopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
        public virtual DbSet<EventoLimpieza> EventoLimpiezas { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public virtual DbSet<Geoubicacion> Geoubicacions { get; set; }
        public virtual DbSet<Patrocinador> Patrocinadors { get; set; }
        public virtual DbSet<Poi> Pois { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-AP83LF2M; Database=gb_shop; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiqueta>(entity =>
            {
                entity.HasKey(e => e.IdEtiqueta);

                entity.Property(e => e.IdEtiqueta).HasColumnName("id_etiqueta");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdFoto).HasColumnName("id_foto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdFotoNavigation)
                    .WithMany(p => p.Etiqueta)
                    .HasForeignKey(d => d.IdFoto)
                    .HasConstraintName("FK_Etiqueta_Foto");
            });

            modelBuilder.Entity<EventoLimpieza>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.ToTable("Evento_limpieza");

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.Asistencias).HasColumnName("asistencias");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdFoto).HasColumnName("id_foto");

                entity.Property(e => e.IdGeoubicacion).HasColumnName("id_geoubicacion");

                entity.Property(e => e.IdPatrocinador).HasColumnName("id_patrocinador");

                entity.Property(e => e.PersonasRequeridas).HasColumnName("personas_requeridas");

                entity.HasOne(d => d.IdFotoNavigation)
                    .WithMany(p => p.EventoLimpiezas)
                    .HasForeignKey(d => d.IdFoto)
                    .HasConstraintName("FK_Evento_limpieza_Foto");

                entity.HasOne(d => d.IdGeoubicacionNavigation)
                    .WithMany(p => p.EventoLimpiezas)
                    .HasForeignKey(d => d.IdGeoubicacion)
                    .HasConstraintName("FK_Evento_limpieza_Geoubicacion");

                entity.HasOne(d => d.IdPatrocinadorNavigation)
                    .WithMany(p => p.EventoLimpiezas)
                    .HasForeignKey(d => d.IdPatrocinador)
                    .HasConstraintName("FK_Evento_limpieza_Patrocinador");
            });

            modelBuilder.Entity<Foto>(entity =>
            {
                entity.HasKey(e => e.IdFoto);

                entity.ToTable("Foto");

                entity.Property(e => e.IdFoto).HasColumnName("id_foto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Geoubicacion>(entity =>
            {
                entity.HasKey(e => e.IdGeoubicacion);

                entity.ToTable("Geoubicacion");

                entity.Property(e => e.IdGeoubicacion).HasColumnName("id_geoubicacion");

                entity.Property(e => e.Latitud).HasColumnName("latitud");

                entity.Property(e => e.Longitud).HasColumnName("longitud");
            });

            modelBuilder.Entity<Patrocinador>(entity =>
            {
                entity.HasKey(e => e.IdPadrocinador);

                entity.ToTable("Patrocinador");

                entity.Property(e => e.IdPadrocinador).HasColumnName("id_padrocinador");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdFoto).HasColumnName("id_foto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdFotoNavigation)
                    .WithMany(p => p.Patrocinadors)
                    .HasForeignKey(d => d.IdFoto)
                    .HasConstraintName("FK_Patrocinador_Foto");
            });

            modelBuilder.Entity<Poi>(entity =>
            {
                entity.HasKey(e => e.IdPoi);

                entity.ToTable("POI");

                entity.Property(e => e.IdPoi).HasColumnName("id_poi");

                entity.Property(e => e.Confirmaciones).HasColumnName("confirmaciones");

                entity.Property(e => e.IdReporte).HasColumnName("id_reporte");

                entity.Property(e => e.Negaciones).HasColumnName("negaciones");

                entity.HasOne(d => d.IdReporteNavigation)
                    .WithMany(p => p.Pois)
                    .HasForeignKey(d => d.IdReporte)
                    .HasConstraintName("FK_POI_POI");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte);

                entity.ToTable("Reporte");

                entity.Property(e => e.IdReporte).HasColumnName("id_reporte");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEtiqueta).HasColumnName("id_etiqueta");

                entity.Property(e => e.IdFoto).HasColumnName("id_foto");

                entity.Property(e => e.IdGeoubicacion).HasColumnName("id_geoubicacion");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdEtiquetaNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdEtiqueta)
                    .HasConstraintName("FK_Reporte_Etiqueta");

                entity.HasOne(d => d.IdFotoNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdFoto)
                    .HasConstraintName("FK_Reporte_Foto");

                entity.HasOne(d => d.IdGeoubicacionNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdGeoubicacion)
                    .HasConstraintName("FK_Reporte_Geoubicacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Reporte_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.IdFoto).HasColumnName("id_foto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdFotoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdFoto)
                    .HasConstraintName("FK_Usuario_Foto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
