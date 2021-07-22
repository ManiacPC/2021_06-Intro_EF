using System;
using Microsoft.EntityFrameworkCore;

namespace Intro_EF.Models
{
    public class EfContext : DbContext // Heredar desdes DbContext
    {
        // 1. Conectar a la base de datos
        private const string ConnectionString = "server=localhost;port=3306;database=test_db;user=root;password=12345";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString,
                new MySqlServerVersion(new Version(8, 0, 11))); 
        }
        
        // 2. Definir qué clases son modelos desde la base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        
        // 3. Configurar los modelos
        // * Definir clave primaria * Establecer las relaciones
        // * Definir cuáles son obligatorios
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir claves primarias OK
            modelBuilder.Entity<Usuario>().HasKey(i => i.id);
            modelBuilder.Entity<Venta>().HasKey(j => j.id);
            
            // Definir relaciones uno a muchos OK
            modelBuilder.Entity<Venta>()
                .HasOne<Usuario>(s => s.Usuario)
                .WithMany(g => g.Ventas)
                .HasForeignKey(s => s.usuario_id);
            
            // Definimos los obligatorios (not null - mandatory) OK
            modelBuilder.Entity<Usuario>().Property(s => s.username).IsRequired();
            modelBuilder.Entity<Usuario>().Property(s => s.password).IsRequired();
            
            DateTime fechaActual = DateTime.Now; // Opcional, se le asigna un valor por defecto
            
            modelBuilder.Entity<Venta>().Property(s => s.fecha).HasDefaultValue(fechaActual).IsRequired();
            modelBuilder.Entity<Venta>().Property(s => s.total).IsRequired();
            modelBuilder.Entity<Venta>().Property(s => s.usuario_id).IsRequired();




        }
    }
}