using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinos.Models
{

    [Serializable]
    public class ItemPedido
    {
        [Key]
        public int IdItem{ get; set; }

        [Required(ErrorMessage = "Escriba IdPedido")]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "Escriba IdVino")]
        public int IdVino { get; set; }

        [Required(ErrorMessage = "Escriba la descripcion.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(200, ErrorMessage = "Escriba menos de 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Escriba IdDiseño")]
        public int IdDiseño { get; set; }

        [Required(ErrorMessage = "Escriba la cantidad.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Escriba el precio")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public double Precio { get; set; }

    }
}
