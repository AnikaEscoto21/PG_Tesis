using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Usuarios
{
    public class RolViewModel
    {
        [Required]
        public int IdRol { get; set; }

        [Required, StringLength(80)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres.")]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;
    }
}
