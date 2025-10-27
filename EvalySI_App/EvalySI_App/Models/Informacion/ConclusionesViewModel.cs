using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class ConclusionesViewModel
    {
        [Required]
        public int CandidatoId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? ExperienciaChantajeable { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? PensabaPreguntasFaltantes { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? FalseoOmisiones { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? AlgoQuePreocupe { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool? AlgoQueDecir { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? ObjetivosCP {  get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? ObjetivosMP { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? ObjetivosLP { get; set; }
    }
}
