using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Legal
{
    public class DrogasViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(40)]
        public string? UltimaVezConsumo { get; set; }

        public bool ProboDrogas { get; set; } = false;

        public bool CualquierContacto { get; set; } = false;

        public bool GuardoDrogaAjena { get; set; } = false;

        public bool ContactoConVendedores { get; set; } = false;

        public bool FamiliarConsume { get; set; } = false;
    }
}
