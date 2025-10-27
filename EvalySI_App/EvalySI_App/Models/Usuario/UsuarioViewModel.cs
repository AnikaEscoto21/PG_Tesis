using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Usuarios
{
    public class UsuarioViewModel
    {
        [Required]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MinLength(12, ErrorMessage = "El contraseña no puede tener menos de 12 caracteres.")]
        public string HashPassword { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; }

    }
}
