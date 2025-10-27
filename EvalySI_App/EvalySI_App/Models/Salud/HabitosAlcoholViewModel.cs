using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Salud
{
    public class HabitosAlcoholViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(40)] 
        public string? UltimaVezBebio { get; set; }

        [StringLength(40)] 
        public string? PromedioMensual { get; set; }

        public int? ExcesosPorAnio { get; set; }

        [StringLength(100)] 
        public string? ComoEsCuandoExcede { get; set; }

        [StringLength(40)] 
        public string? UltimaAmnesia { get; set; }

        [StringLength(40)] 
        public string? UltimaConduccionEbrio { get; set; }

        [StringLength(100)] 
        public string? PeorEvento { get; set; }

        public bool PeleaAlBeber { get; set; } = false;

        public bool DetenidoAlBeber { get; set; } = false;

        public bool TratamientoControlBeber { get; set; } = false;

        public bool LaboroEbrioResaca { get; set; } = false;

        public bool FaltoPorBeber { get; set; } = false;

        public bool BebioEnHorasTrabajo { get; set; } = false;
    }
}
