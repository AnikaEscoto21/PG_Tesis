using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Economia
{
    public class TarjetaCreditoViewModel
    {
        public int IdTarjeta { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(80)] 
        public string Banco { get; set; } = string.Empty;

        public decimal? LimiteCredito { get; set; }

        public decimal? SaldoActual { get; set; }
    }
}
