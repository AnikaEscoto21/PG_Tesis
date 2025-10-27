using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Salud
{
    public class CatCondicionMedicaViewModel
    {
        public int IdCM { get; set; }

        [Required, StringLength(60)] 
        public string Nombre { get; set; } = string.Empty;
    }

    public class HistoriaMedicaCondViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(100)]
        public string CondicionNombre { get; set; } = string.Empty;

        [StringLength(200)] 
        public string? Especificar { get; set; }

        [StringLength(40)] 
        public string? Fecha { get; set; }
    }
}
