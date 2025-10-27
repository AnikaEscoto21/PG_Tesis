using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class AspectosEmocionalesViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        public bool VivenPadres { get; set; } = false;

        [StringLength(150)] 
        public string? RelacionEntrePadres { get; set; }

        [StringLength(150)] 
        public string? ConQuienVive { get; set; }

        [StringLength(150)]
        public string? IntentosSuicidio { get; set; }

        [StringLength(120)] 
        public string? CualidadRespeta { get; set; }

        [StringLength(120)] 
        public string? DefectoIntolerable { get; set; }

        [StringLength(200)] 
        public string? MejorExperiencia { get; set; }

        [StringLength(200)] 
        public string? PeorExperiencia { get; set; }
    }
}
