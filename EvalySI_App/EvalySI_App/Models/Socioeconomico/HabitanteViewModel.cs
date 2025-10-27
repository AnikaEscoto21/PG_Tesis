using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Socioeconomico
{
    public class HabitanteViewModel
    {
        public class HabitanteViviendaViewModel
        {
            public int Id { get; set; }

            [Required] 
            public int CandidatoId { get; set; }

            [Required, StringLength(120)] 
            public string Nombre { get; set; } = string.Empty;

            [StringLength(60)] 
            public string? Parentesco { get; set; }

            [MaxLength(2)]
            public int? Edad { get; set; }

            public bool? AportaAGastos { get; set; }

            [Range(0, double.MaxValue)] 
            public decimal? CantidadAporte { get; set; }
        }
    }
}
