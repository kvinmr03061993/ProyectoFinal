using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVinos.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        
        [Required(ErrorMessage = "Escriba su nombre.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Escriba su primer apellido.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string PrimerApellido { get; set; }
        
        [Required(ErrorMessage = "Escriba su segundo apellido.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string SegundoApellido { get; set; }
        
        [Required(ErrorMessage = "Escriba su correo.")]
        [EmailAddress(ErrorMessage = "Escriba un correo valido.")]
        public string Correo { get; set; }
        
        [Required(ErrorMessage = "Escriba su telefono.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "Escriba su usuario")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Usuario { get; set; }
        
        [Required(ErrorMessage = "Escriba su clave")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Pass { get; set; }
        
        [Required(ErrorMessage = "Escriba su direccion.")]
        [MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        [MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Direccion { get; set; }
        
        [Required(ErrorMessage = "Escriba su privincia.")]
        //[MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        //[MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Provincia { get; set; }
        
        [Required(ErrorMessage = "Escriba su canton.")]
        //[MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        //[MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Canton { get; set; }
        
        [Required(ErrorMessage = "Escriba su distrito.")]
        //[MinLength(4, ErrorMessage = "Escriba mas de 4 caracteres")]
        //[MaxLength(50, ErrorMessage = "Escriba menos de 50 caracteres")]
        public string Distrito { get; set; }
        
        [Required(ErrorMessage = "Escriba su fecha nacimiento.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string Rol { get; set; }
    }
}
