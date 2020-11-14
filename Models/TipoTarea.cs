using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace Proyecto.Models
{
    public class TipoTarea
    {
        [Key]
        public int TareaId { get; set; }
        public string DesTarea { get; set; }
        public virtual List<TareaDetalle> Detalle { get; set; } = new List<TareaDetalle>();

        public TipoTarea()
        {
            TareaId = 0;
            DesTarea = string.Empty;

        }

    }

}
