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

        public DbSet<Dispositivos> Dispositivos { get; set; }
        public DbSet<Datos> Datos { get; set; }

        #endregion

        #region Formato de tablas y columnas de la bd
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dispositivos>(entity =>
            {
                //Nombre de Tabla en la BD
                entity.ToTable("cultivos");

                //IsRequired(): Propiedad Obligatoria
                //HasMaxLength(num_int): Máximo 'num_int' caracteres
                //IsUnicode(false): Configura si la propiedad admite o no contenido de cadena Unicode.
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50).IsUnicode(false);

                //Personaliza el nombre de la columna en la BD.
                entity.Property(e => e.ProgramaId).HasColumnName("Programa_Id");

                //RELACION UNO A MUCHOS.
                //----------------------
                //HasOne(d => d.EntidadForanea): Para las llaves foráneas se utiliza la opción HasOne donde
                //pasamos como parámetro la entidad foranea, en este caso 'Programa'. Se lee en la clase actual.
                //WithMany(p => p.Entidad): Se configura la Entidad Actual, en este caso 'ColumnaLibro'. Se lee desde la clase Foranea.
                //HasForeignKey(d => d.EntidadForanea_Id): Configura las propiedades que se van a usar como clave externa para esta relación
                //OnDelete(DeleteBehavior.ClientSetNull): No permite la eliminacion en cascada.
                //Entity Framework aplica ON DELETE CASCADE por defecto a las relaciones requeridas
                //HasConstraintName("FK_cultivos_programas"): Nombre de la relación en la BD.
                entity.HasOne(d => d.Programa)
            .WithMany(p => p.Cultivos)
            .HasForeignKey(d => d.ProgramaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_cultivos_programas");
            });

        }

        #endregion


    }
}