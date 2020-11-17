using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Tarea
    {
        [Key]
        public int TareaId { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public string Requerimiento { get; set; }

        public double TiempoTotal { get; set; }


        [ForeignKey("TareaId")]
        public virtual List<TareaDetalle> Detalle { get; set; }


        public Tarea()
        {
            TareaId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
            Requerimiento = string.Empty;
            TiempoTotal = 0;
            Detalle = new List<TareaDetalle>();

        }

        /*  public Tarea(int proyectoId, DateTime fecha, string descripicion, TareaDetalle tareaDetalle, List<TareaDetalle> detalle)
          {
              ProyectoId = proyectoId;
              Fecha = fecha;
              Descripicion = descripicion;
              TareaDetalle = tareaDetalle;
              Detalle = detalle;
          }*/
    }
}
