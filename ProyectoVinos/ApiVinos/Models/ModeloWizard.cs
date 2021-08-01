using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoVinos.Models;

namespace ProyectoVinos.Models
{

    
    public class ModeloWizard
    {
        public int IdVino { get; set; }
        public int IdDiseño { get; set; }

        public IEnumerable<SelectListItem> VinoList { get; set; }
        public IEnumerable<SelectListItem> DiseñoList { get; set; }

        public Vino Vino { get; set; }
        public Diseño Diseño { get; set; }


        public String Descripcion { get; set; }

        public double PrecioTotal { get; set; }

        public DateTime FechaEntrega { get; set; }
    

    }
}
