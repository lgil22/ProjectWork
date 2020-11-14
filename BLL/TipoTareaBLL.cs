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
        public static List<TipoTarea> GetList(Expression<Func<TipoTarea, bool>> producto)
        {
            List<TipoTarea> lista = new List<TipoTarea>();
            Contexto db = new Contexto();

            try
            {
                lista = db.TipoTarea.Where(producto).ToList();
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