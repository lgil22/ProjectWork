using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.BLL;
using Proyecto.Models;
using Proyecto.DAL;

namespace Proyecto.Models
{
    public class TareaDetalle
    {
        [Key]
        public int TareaDetalleId { get; set; }
        public int TareaId { get; set; }
        public int TipoTareaId { get; set; }
       
        public string Requerimiento { get; set; }
        public double Tiempo { get; set; }
     
       
        public TareaDetalle()
        {
            TareaDetalleId = 0;
            TareaId = 0;
            TipoTareaId = 0;
            Requerimiento = string.Empty;
            Tiempo = 0;
           

        }
    }
}