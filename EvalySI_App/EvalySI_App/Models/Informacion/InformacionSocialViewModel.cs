using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class InformacionSocialViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(80)] 
        public string? Religion { get; set; }

        [StringLength(80)] 
        public string? FrecuenciaCulto { get; set; }

        [StringLength(150)] 
        public string? Grupos { get; set; }

        [Required(ErrorMessage = "El campo Actividades em su tiempo libre es obligatorio")]
        [StringLength(150)] 
        public string? ActividadesTiempoLibre { get; set; }

        [Required(ErrorMessage = "El campo Autodescripcion es obligatorio")]
        [StringLength(200)] 
        public string? Autodescripcion { get; set; }

        [StringLength(100)] 
        public string? Piercings { get; set; }

        public bool? Tatuajes { get; set; }

        [StringLength(100)] 
        public string? TatuajesDescripcion { get; set; }
    }
}
