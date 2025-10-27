using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models
{
    public class BitacoraViewModel
    {
        public int Id { get; set; }

        [Required] 
        public int UsuarioId { get; set; }

        [Required, StringLength(40)] 
        public string Accion { get; set; } = string.Empty;

        public string? Detalle { get; set; }

        [StringLength(64)] 
        public string? IpOrigen { get; set; }

        public DateTime CreadoEn { get; set; }
    }
}
