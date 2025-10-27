using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Economia
{
    public class CuentaBancariaViewModel
    {
        public int IdCuenta { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(80)] 
        public string Banco { get; set; } = string.Empty;

        [StringLength(40)] 
        public string? TipoCuenta { get; set; }

        public decimal? Saldo { get; set; }
    }
}
