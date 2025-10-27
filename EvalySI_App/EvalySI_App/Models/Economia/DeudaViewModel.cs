using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Economia
{
    public class DeudaViewModel
    {
        public int IdDeudas { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(80)] 
        public string? Banco { get; set; }

        public decimal? MontoMensual { get; set; }

        [StringLength(200)] 
        public string? Razon { get; set; }
    }
}
