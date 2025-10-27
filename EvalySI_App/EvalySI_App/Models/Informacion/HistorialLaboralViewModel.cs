using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class HistorialLaboralViewModel
    {
        public long Id { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(200)] 
        public string Empresa { get; set; } = string.Empty;

        [StringLength(120)] 
        public string? Cargo { get; set; }

        [StringLength(10)] 
        public string? TelefonoEmpresa { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaIngreso { get; set; }

        [DataType(DataType.Date)] 
        public DateTime? FechaEgreso { get; set; }

        public decimal? UltimoSalario { get; set; }

        [StringLength(200)] 
        public string? CausaRetiro { get; set; }

        [StringLength(100)]
        public string? JefeInmediato { get; set; }

        [StringLength(10)] 
        public string? TelefonoJefe { get; set; }

        [StringLength(100)] 
        public string? CargoJefe { get; set; }

        [StringLength(200)] 
        public string? Observaciones { get; set; }
    }
}
