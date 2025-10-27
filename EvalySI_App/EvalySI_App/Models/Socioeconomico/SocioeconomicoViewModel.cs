using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Socioeconomico
{
    public class SocioeconomicoViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        public int? PersonasDependen { get; set; }

        public bool TieneIngresoExtra { get; set; }

        [StringLength(100)] 
        public string? DetalleIngresoExtra { get; set; }

        public decimal? IngresosHogarAprox { get; set; }

        public string? TipoVivienda { get; set; }

        public string? TenenciaVivienda { get; set; }

        [StringLength(100)] 
        public string? AdquisicionVivienda { get; set; }

        public decimal? MontoAlquiler { get; set; }

        [StringLength(100)]
        public string? QuienesPaganAlquiler { get; set; }

        [StringLength(60)] 
        public string? TiempoVivirAhi { get; set; }

        [StringLength(100)] 
        public string? DomicilioAnterior { get; set; }

        [StringLength(200)] 
        public string? MotivoCambioDomicilio { get; set; }
    }
}
