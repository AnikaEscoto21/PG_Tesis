using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Legal
{
    public class ManejoArmasViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }    

        public bool TieneArmasPropias { get; set; } = false;

        public bool HaPortadoArma { get; set; } = false;

        public bool EnfrentamientoConArma { get; set; } = false;

        public bool DisparoInnecesario { get; set; } = false;

        public bool UsoIndebidoArma { get; set; } = false;

        public bool CompraVentaIlegalArmas { get; set; } = false;
    }
}
