using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<TipoTarea> TipoTarea { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data\Tareas.db"); ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea() { TipoTareaId = 1, DesTarea = "Analisis" });

            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea() { TipoTareaId = 2, DesTarea = "Diseño" });

            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea() { TipoTareaId = 3, DesTarea = "Programación" });

            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea() { TipoTareaId = 4, DesTarea = "Prueba" });

        }
    }
}