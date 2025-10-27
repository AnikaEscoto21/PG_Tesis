using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Socioeconomico
{
    public class ReferenciaViewModel
    {
        public int Id { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [Required]
        public string TipoReferencia { get; set; }

        [Required, StringLength(100)] 
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(25)] 
        public string Telefono { get; set; } = string.Empty;

        [StringLength(60)] 
        public string? Parentesco { get; set; }

        [StringLength(40)]
        public string? TiempoConocer { get; set; }

        [StringLength(200)]
        public string? Notas { get; set; }
    }
}
