using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Socioeconomico
{
    public class ViviendaViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(100)] 
        public string? ColorExterior { get; set; }

        [StringLength(100)] 
        public string? ColorInterior { get; set; }

        [StringLength(100)] 
        public string? TipoParedes { get; set; }

        [StringLength(100)] 
        public string? TipoTecho { get; set; }

        public int? Niveles { get; set; }

        [StringLength(150)] 
        public string? ConstruccionDe { get; set; }

        public int? NumeroAmbientes { get; set; }

        [StringLength(500)] 
        public string? AmbientesDetalle { get; set; }

        public decimal? MtsFrente { get; set; }

        public decimal? MtsFondo { get; set; }

        [RegularExpression("Asfalto|Pavimento|Adoquín|Terracería|Otro")]
        public string? CallesTipo { get; set; }

        [StringLength(100)] 
        public string? CallesTipoOtro { get; set; }

        [StringLength(600)] 
        public string? EquipadoCon { get; set; }

        [StringLength(200)] 
        public string? ComercioEnVivienda { get; set; }
    
    }
}
