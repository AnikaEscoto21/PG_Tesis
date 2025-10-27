using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Salud
{
    public class HistoriaMedicaViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(80)] 
        public string? CondicionGeneral { get; set; }

        [StringLength(100)] 
        public string? MalestarActual { get; set; }

        [StringLength(5)] 
        public string? HoraUltimaComida { get; set; }

        [StringLength(5)] 
        public string? HorasDormidasAyer { get; set; }

        public bool Embarazo { get; set; } = false;

        [StringLength(100)] 
        public string? EnfermedadGrave { get; set; }
    }
}
