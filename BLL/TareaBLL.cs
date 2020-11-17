using Microsoft.EntityFrameworkCore;
using Proyecto.DAL;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proyecto.BLL
{
    public class TareaBLL
    {
        public static bool Guardar(Tarea tarea)
        {
            if (!Existe(tarea.TareaId))
                return Insertar(tarea);
            else
                return Modificar(tarea);

        }

        private static bool Insertar(Tarea tarea)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Tareas.Add(tarea);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        private static bool Modificar(Tarea tarea)
        {
            bool paso = false;
            var Anterior = Buscar(tarea.TareaId);
            Contexto contexto = new Contexto();

            try
            { 
                foreach (var item in Anterior.Detalle)
                {
                    var auxTarea = contexto.TipoTarea.Find(item.TareaId);
                    if (!tarea.Detalle.Exists(d => d.TareaDetalleId == item.TareaDetalleId))
                    {
                        if (auxTarea != null)
                            contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                foreach (var item in tarea.Detalle)
                {
                    if (item.TareaDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;


                    }
                    else
                        contexto.Entry(item).State = EntityState.Modified;
                }


                contexto.Entry(tarea).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (Existe(id))
                {
                    var _tarea = contexto.Tareas.Find(id);
                    if (_tarea != null)
                    {
                        contexto.Tareas.Remove(_tarea);
                        paso = contexto.SaveChanges() > 0;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Tarea Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Tarea tarea;

            try
            {
                tarea = contexto.Tareas.Where(x => x.TareaId == id).Include(d => d.Detalle).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tarea;

        }

        public static List<Tarea> GetList(Expression<Func<Tarea, bool>> expression)
        {
            List<Tarea> lista = new List<Tarea>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Tareas.Where(expression).ToList();
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

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Tareas.Any(o => o.TareaId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }


    }
}