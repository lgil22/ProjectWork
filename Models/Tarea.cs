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
        public int ProyectoId { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        public string Descripicion { get; set; }

        public int TareaId { get; set; }
        public string DesTarea { get; set; }


        [ForeignKey("ProyectoId")]
        public virtual List<TareaDetalle> TareaDetalle { get; set; }


        public Tarea()
        {
            ProyectoId = 0;
            TareaId = 0;
            Fecha = DateTime.Now;
            Descripicion = string.Empty;

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
