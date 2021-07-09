using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinos.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "Escriba IdCliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Escriba la fecha de creacion.")]
        public DateTime FechaCreacion { get; set; }

        
        [Required(ErrorMessage = "Escriba la fecha de entrega.")]
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "Escriba el precioTotal")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public double PrecioTotal { get; set; }

        [Required(ErrorMessage = "Escriba el estado.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(32, ErrorMessage = "Escriba menos de 32 caracteres")]
        public string Descripcion { get; set; }


    }
}
