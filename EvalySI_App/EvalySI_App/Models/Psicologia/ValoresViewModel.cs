using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class ValoresViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        public bool HonestaIdentidad { get; set; } = false;

        public bool DocumentoFalsoEnPlaza { get; set; } = false;

        public bool ManejoValores { get; set; } = false;

        public bool Faltantes { get; set; } = false;

        public bool Sobrantes { get; set; } = false;

        public bool PrestamosConDineroACargo { get; set; } = false;

        public bool ManejoInfoConf { get; set; } = false;

        public bool UsoIndebidoInfoConf { get; set; } = false;
    }
}
