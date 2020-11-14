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
            optionsBuilder.UseSqlite(@"Data source = Data\\Tarea.db"); ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea() { TareaId = 1, DesTarea = "Analisis" });

            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea() { TareaId = 2, DesTarea = "Diseño" });

            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea() { TareaId = 3, DesTarea = "Programación" });

            modelBuilder.Entity<TipoTarea>().HasData(new TipoTarea() { TareaId = 4, DesTarea = "Prueba" });

        }
    }
}