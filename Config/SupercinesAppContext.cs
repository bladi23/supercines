using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using supercines.Models;




namespace supercines.Config
{
    public class SupercinesAppContext : DbContext
    {
        public SupercinesAppContext(DbContextOptions contexto) : base(contexto)
        {
        }
        public DbSet<peliculasModel> Peliculas { get; set; }
        public DbSet<personasModel> Personas { get; set; }
        public DbSet<repartosModel> Repartos { get; set; }
        public DbSet<cinesModel> Cines { get; set; }
        public DbSet<salasModel> Salas { get; set; }
        public DbSet<funcionesModel> Funciones { get; set; }
        public DbSet<promocionesModel> Promociones { get; set; }
        public DbSet<opinionesModel> Opiniones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Películas → Reparto (Uno a Muchos)
            modelBuilder.Entity<repartosModel>()
                .HasOne(r => r.Pelicula)
                .WithMany(p => p.Reparto)
                .HasForeignKey(r => r.PeliculaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Personas → Reparto (Uno a Muchos)
            modelBuilder.Entity<repartosModel>()
                .HasOne(r => r.Persona)
                .WithMany()  // Si no tienes una lista de Repartos en personasModel
                .HasForeignKey(r => r.PersonaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<funcionesModel>()
                .HasOne(f => f.Pelicula)
                .WithMany()
                .HasForeignKey(f => f.PeliculaId);

            modelBuilder.Entity<funcionesModel>()
                .HasOne(f => f.Sala)
                .WithMany()
                .HasForeignKey(f => f.SalaId);
        }
    }
}

