using Proyecto.DAL;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proyecto.BLL
{
    public class TipoTareaBLL
    {
        public static TipoTarea Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TipoTarea _tipo;

            try
            {
                _tipo = contexto.TipoTarea.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return _tipo;

        }
        public static List<TipoTarea> GetList(Expression<Func<TipoTarea, bool>> tarea)
        {
            List<TipoTarea> lista = new List<TipoTarea>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.TipoTarea.Where(tarea).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

    }
}