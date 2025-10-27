using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.DatosGenerales
{
    public class HijoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CandidatoId { get; set; }

        [StringLength(100)]
        public string NombreHijo { get; set; } = string.Empty;

        [Range(0, 99)]
        public int? EdadHijo { get; set; }

        [StringLength(200)] 
        public string? Direccion { get; set; }

        [StringLength(100)] 
        public string? Ocupacion { get; set; }

        [StringLength(40)]
        public string? EstadoCivilHijo { get; set; }

        [StringLength(60)] 
        public string? Nacionalidad { get; set; }

        [StringLength(200)] 
        public string? LugarTrabajo { get; set; }
    }
}
