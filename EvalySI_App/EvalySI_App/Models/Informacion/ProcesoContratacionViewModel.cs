using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class ProcesoContratacionViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? OcultoIdentidad { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? OmisionDeliberada { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? DocumentoFalso { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? InfoFalsaCV { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? DocumentosEnOrden { get; set; }

        [StringLength(200)]
        public string? Observaciones { get; set; }
    }
}

