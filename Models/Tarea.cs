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

        [ForeignKey("ProyectoId")]

        //public virtual TareaDetalle TareaDetalle { get; set; }
        public virtual List<TareaDetalle> Detalle { get; set; } = new List<TareaDetalle>();

        public Tarea()
        {
            ProyectoId = 0;
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
