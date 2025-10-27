using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Legal
{
    public class AntecedentesViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        public bool CausoHeridasGraves { get; set; } = false;

        public bool MatoAlguien { get; set; } = false;

        [StringLength(120)] 
        public string? UltimaRina { get; set; }

        [StringLength(150)] 
        public string? UltimaPerdidaControl { get; set; }

    }
}
