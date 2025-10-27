using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Socioeconomico
{
    public class ObjetivoViewModel
    {
        public long Id { get; set; }
        [Required] 
        public int CandidatoId { get; set; }

        [Required] 
        public string Horizonte { get; set; }

        [Required, StringLength(200)] 
        public string Descripcion { get; set; } = string.Empty;
    }
}
