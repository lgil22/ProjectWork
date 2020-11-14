using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.DAL;
using Proyecto.Models;

namespace Proyecto.BLL
{
    public class TareaBLL
    {

        public static bool Guardar(Tarea tarea)
        {
            if (!Existe(tarea.ProyectoId))
                return Insertar(tarea);
            else
                return Modificar(tarea);
        }

        private static bool Insertar(Tarea tarea)
        {
            bool Insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in tarea.Detalle)
                {
                    item.Tareas = contexto.Tareas.Find(item.ProyectoId);
                    contexto.Entry(item.Tareas).State = EntityState.Modified;
                }
                contexto.Tareas.Add(tarea);
                Insertado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Insertado;
        }

        private static bool Existe(int id)
        {
            bool existencia;
            Contexto contexto = new Contexto();

            try
            {
                existencia = contexto.Tareas.Any(p => p.ProyectoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return existencia;
        }

        public static bool Modificar(Tarea tarea)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM TareaDetalle Where ProyectoId={tarea.ProyectoId}");
                foreach (var item in tarea.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(tarea).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Tarea Buscar(int id)
        {
            Contexto db = new Contexto();
            Tarea tarea = new Tarea();

            try
            {
                tarea = db.Tareas.Include(x => x.Detalle)
                    .Where(x => x.ProyectoId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return tarea;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = TareaBLL.Buscar(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }


        public static List<Tarea> GetList(Expression<Func<Tarea, bool>> tarea)
        {
            List<Tarea> lista = new List<Tarea>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Tareas.Where(tarea).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}