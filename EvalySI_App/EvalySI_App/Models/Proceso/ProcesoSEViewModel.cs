using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Proceso
{
    public class ProcesoSEViewModel
    {
        public int IdProceso { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        public bool FormularioCompletado { get; set; }

        public bool EntrevistaRealizada { get; set; }

        public bool PruebaAplicada { get; set; }

        [RegularExpression("PENDIENTE|EN_PROCESO|COMPLETADO|CANCELADO")] 
        public string Estado { get; set; } = "PENDIENTE";

        [RegularExpression("PENDIENTE|APROBADO|NO_APROBADO")] 
        public string Resultado { get; set; } = "PENDIENTE";

        [StringLength(400)] 
        public string? Observaciones { get; set; }

        public DateTime CreadoEn { get; set; }

        public DateTime ActualizadoEn { get; set; }
    }
}
