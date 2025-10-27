using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Informacion
{
    public class EstudioViewModel
    {
        public int IdEstudio { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [Required(ErrorMessage = "El campo Nombre Institución es obligatorio")]
        [StringLength(200)] 
        public string NombreInstitucion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Estudios Realizados es obligatorio")]
        [StringLength(200)] 
        public string EstudiosRealizados { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Lugar es obligatorio")]
        [StringLength(120)] 
        public string? Lugar { get; set; }

        [Required(ErrorMessage = "El campo Fecha desde es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime? FechaDesde { get; set; }

        [Required(ErrorMessage = "El campo Fecha Hasta es obligatorio")]
        [DataType(DataType.Date)] 
        public DateTime? FechaHasta { get; set; }

        [Required(ErrorMessage = "El campo Ultimo grado es obligatorio")]
        [StringLength(100)] 
        public string? UltimoGrado { get; set; }
    }
}
