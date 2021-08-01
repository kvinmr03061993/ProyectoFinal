using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinos.Models
{

    [Serializable]
    public class Diseño
    {
        [Key]
        public int IdDiseño { get; set; }

        [Required(ErrorMessage = "Escriba el nombre.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(64, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escriba la descripcion.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(64, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Descripcion { get; set; }

    }
}
