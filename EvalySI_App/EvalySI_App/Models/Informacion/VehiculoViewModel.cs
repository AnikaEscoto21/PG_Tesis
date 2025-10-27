using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class VehiculoViewModel
    {
        public int Id { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(60)]
        public string? Marca { get; set; }

        [StringLength(40)] 
        public string? Modelo { get; set; }

        [StringLength(25)] 
        public string? Placas { get; set; }
    }
}
