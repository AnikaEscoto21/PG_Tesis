using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class PreguntasLaboralesViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? PedidoRenuncia { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? AbandonoEmpleo { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? AcusadoDeshonestidad { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? VReglamentos { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? BeneficiosIlicitos { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? UsoIndebidoInfoConf { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? DiscusionesConSuperiores { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? ActaAdmOProceso { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? Sobornos { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? Sabotaje { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? DemandaContra { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? DemandaAAlguien { get; set; }

        [StringLength(200)] 
        public string? Observaciones { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(200)] 
        public string? ProblemasLaborales { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(200)] 
        public string? FaltasAdmSerias { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(200)]
        public string? OpinionSindicatos { get; set; }
    }
}
