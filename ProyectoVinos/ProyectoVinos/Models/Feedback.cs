using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinos.Models
{
    public class Feedback
    {
        [Key]
        public int IdFeedback { get; set; }

        [Required(ErrorMessage = "Escriba IdVino")]
        public int IdVino { get; set; }


        [Required(ErrorMessage = "Escriba su comentario.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(512, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "Escriba su calificacion.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public int Calificacion { get; set; }

    }
}
