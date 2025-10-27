using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.DatosGenerales
{
    public class HermanoViewModel
    {
        public int IdHermano { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [StringLength(120)] 
        public string Nombre { get; set; } = string.Empty;

        [Range (0, 99)]
        public int? Edad { get; set; }

        [StringLength(8)] 
        public string? NoResidencia { get; set; }

        [StringLength(13)] 
        public string? DPI { get; set; }

        [StringLength(40)] 
        public string? EstadoCivil { get; set; }

        [StringLength(8)] 
        public string? Celular { get; set; }

        [StringLength(120)] 
        public string? Profesion { get; set; }

        [StringLength(60)] 
        public string? Nacionalidad { get; set; }

        [StringLength(200)] 
        public string? LugarTrabajo { get; set; }
    }
}
