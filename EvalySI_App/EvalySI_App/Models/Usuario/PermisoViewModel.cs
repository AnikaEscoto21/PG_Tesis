using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Usuarios
{
    public class PermisoViewModel
    {
        [Required]
        public int IdPermiso { get; set; }

        [Required]

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;
    }
}
