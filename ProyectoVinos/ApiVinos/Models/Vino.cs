using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinos.Models
{

    [Serializable]
    public class Vino
    {


        [Key]
        public int IdVino { get; set; }

     
        public string Nombre { get; set; }

    
        public double PrecioBase { get; set; }



    }
}
