using dotnet6_web_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region Entidades del modelo
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Dato> Datos { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<KitDispositivo> KitDispositivo { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        #endregion

        #region Formateado (mediante la API Fluent) de las tablas y columnas de la bd generada
        //API Fluent: Es una forma avanzada de especificar la configuración del modelo que cubre todo
        //lo que pueden hacer las anotaciones de datos (Ejem: [Column(TypeName = "decimal(5, 2)")]), 
        //además de algunas configuraciones más avanzadas que no son posibles con las anotaciones de 
        //datos. Las anotaciones de datos y la API fluida se pueden usar juntas, pero Code First da 
        //prioridad a la API fluida > anotaciones de datos > convenciones predeterminadas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dispositivo>(entity =>
            {
                //Nombre de Tabla en la BD
                entity.ToTable("dispositivos");

                //IsRequired(): Propiedad Obligatoria
                //HasMaxLength(num_int): Máximo 'num_int' caracteres
                //IsUnicode(false): Configura si la propiedad admite o no contenido de cadena Unicode.
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200).IsUnicode(false);

            });

            modelBuilder.Entity<Dato>(entity =>
            {
                //Nombre de Tabla en la BD.
                entity.ToTable("datos");

                //Crea un indice en la BD.
                entity.HasIndex(e => e.DispositivoId, "IX_datos_Dispositivos_Id");

                //Personaliza el nombre de la columna en la BD.
                entity.Property(e => e.DispositivoId).HasColumnName("Dispositivo_Id");

                //RELACION UNO A MUCHOS.
                //----------------------
                //HasOne(d => d.EntidadForanea): Para las llaves foráneas se utiliza la opción HasOne donde
                //pasamos como parámetro la entidad foranea, en este caso 'UnidadExperimental'. Se lee en la clase actual.
                //WithMany(p => p.Entidad): Se configura la Entidad Actual, en este caso 'Datos'. Se lee desde la clase Foranea.
                //HasForeignKey(d => d.EntidadForanea_Id): Configura las propiedades que se van a usar como clave externa para esta relación
                //OnDelete(DeleteBehavior.ClientSetNull): No permite la eliminacion en cascada.
                //Entity Framework aplica ON DELETE CASCADE por defecto a las relaciones requeridas
                //HasConstraintName("FK_cultivos_programas"): Nombre de la relación en la BD.
                entity.HasOne(d => d.Dispositivo)
                .WithMany(p => p.Datos)
                .HasForeignKey(d => d.DispositivoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_datos_Dispositivos");
            });

            modelBuilder.Entity<Kit>(entity =>
            {
                //Nombre de Tabla en la BD
                entity.ToTable("kits");

                //IsRequired(): Propiedad Obligatoria
                //HasMaxLength(num_int): Máximo 'num_int' caracteres
                //IsUnicode(false): Configura si la propiedad admite o no contenido de cadena Unicode.
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200).IsUnicode(false);

            });

            modelBuilder.Entity<KitDispositivo>(entity =>
            {
                //Nombre de Tabla en la BD.
                entity.ToTable("kits_dispositivos");

                //Crea un indice en la BD.
                entity.HasIndex(e => e.DispositivoId, "IX_kitDispositivo_Dispositivos_Id");

                //Personaliza el nombre de la columna en la BD.
                entity.Property(e => e.DispositivoId).HasColumnName("Dispositivo_Id");

                //RELACION UNO A MUCHOS.
                //----------------------
                //HasOne(d => d.EntidadForanea): Para las llaves foráneas se utiliza la opción HasOne donde
                //pasamos como parámetro la entidad foranea, en este caso 'Dispositivo'. Se lee en la clase actual.
                //WithMany(p => p.Entidad): Se configura la Entidad Actual, en este caso 'Datos'. Se lee desde la clase Foranea.
                //HasForeignKey(d => d.EntidadForanea_Id): Configura las propiedades que se van a usar como clave externa para esta relación
                //OnDelete(DeleteBehavior.ClientSetNull): No permite la eliminacion en cascada.
                //Entity Framework aplica ON DELETE CASCADE por defecto a las relaciones requeridas
                //HasConstraintName("FK_cultivos_programas"): Nombre de la relación en la BD.
                entity.HasOne(d => d.Dispositivo)
                .WithMany(p => p.KitsDispositivos)
                .HasForeignKey(d => d.DispositivoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_kitDispositivo_Dispositivos");

                //Crea un indice en la BD.
                entity.HasIndex(e => e.KitId, "IX_kitDispositivo_Kit_Id");

                //Personaliza el nombre de la columna en la BD.
                entity.Property(e => e.KitId).HasColumnName("Kit_Id");

                //RELACION UNO A MUCHOS.
                //----------------------
                //HasOne(d => d.EntidadForanea): Para las llaves foráneas se utiliza la opción HasOne donde
                //pasamos como parámetro la entidad foranea, en este caso 'Kit'. Se lee en la clase actual.
                //WithMany(p => p.Entidad): Se configura la Entidad Actual, en este caso 'Datos'. Se lee desde la clase Foranea.
                //HasForeignKey(d => d.EntidadForanea_Id): Configura las propiedades que se van a usar como clave externa para esta relación
                //OnDelete(DeleteBehavior.ClientSetNull): No permite la eliminacion en cascada.
                //Entity Framework aplica ON DELETE CASCADE por defecto a las relaciones requeridas
                //HasConstraintName("FK_cultivos_programas"): Nombre de la relación en la BD.
                entity.HasOne(d => d.Kit)
                .WithMany(p => p.KitsDispositivos)
                .HasForeignKey(d => d.KitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_kitDispositivo_Kit");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                //Nombre de Tabla en la BD
                entity.ToTable("tipos");

                //IsRequired(): Propiedad Obligatoria
                //HasMaxLength(num_int): Máximo 'num_int' caracteres
                //IsUnicode(false): Configura si la propiedad admite o no contenido de cadena Unicode.
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200).IsUnicode(false);

            });

        }
        #endregion
    }
}