using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.DatosGenerales
{
    public class PadresViewModel
    {
        [Required]
        public int IdPadre { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Padre es obligatorio")]
        [StringLength(100)] 
        public string NombrePadre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Nombre de la Madre es obligatorio")]
        [StringLength(100)] 
        public string NombreMadre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Edad del Padre es obligatorio")]
        [Range(0, 99)]
        public int? EdadPadre { get; set; }

        [Required(ErrorMessage = "El campo Nombre de la Madre es obligatorio")]
        [Range(0, 99)]
        public int? EdadMadre { get; set; }

        [Required(ErrorMessage = "El campo Numero de Residencia del Padre es obligatorio")]
        [StringLength(40)] 
        public string? NumResidenciaP { get; set; }

        [Required(ErrorMessage = "El campo Numero de Residencia de la Madre es obligatorio")]
        [StringLength(40)]
        public string? NumResidenciaM { get; set; }

        [Required(ErrorMessage = "El campo DPI del Padre es obligatorio")]
        [StringLength(13)] 
        public string? DPIPadre { get; set; }

        [Required(ErrorMessage = "El campo DPI de la Madre es obligatorio")]
        [StringLength(13)]
        public string? DPIMadre{ get; set; }

        [Required(ErrorMessage = "El campo Estado Civil del Padre es obligatorio")]
        [StringLength(40)] 
        public string? EstadoCivilP { get; set; }

        [Required(ErrorMessage = "El campo Estado Civil de la Madre es obligatorio")]
        [StringLength(40)]
        public string? EstadoCivilM { get; set; }

        [Required(ErrorMessage = "El campo Telefono celular del Padre es obligatorio")]
        [StringLength(8)] 
        public string? CelularP { get; set; }

        [Required(ErrorMessage = "El campo Telefono celular de la Madre es obligatorio")]
        [StringLength(8)]
        public string? CelularM { get; set; }

        [Required(ErrorMessage = "El campo Profesion del Padre es obligatorio")]
        [StringLength(100)] 
        public string? ProfesionP { get; set; }

        [Required(ErrorMessage = "El campo Profesion de la Madre es obligatorio")]
        [StringLength(100)]
        public string? ProfesionM { get; set; }

        [Required(ErrorMessage = "El campo Macionalidad del Padre es obligatorio")]
        [StringLength(60)] 
        public string? NacionalidadP { get; set; }

        [Required(ErrorMessage = "El campo Nacionalidad de la Madre es obligatorio")]
        [StringLength(60)]
        public string? NacionalidadM { get; set; }

        [Required(ErrorMessage = "El campo Lugar de Trabajo del Padre es obligatorio")]
        [StringLength(150)] 
        public string? LugarTrabajoP { get; set; }

        [Required(ErrorMessage = "El campo Lugar de Trabajo de la Madre es obligatorio")]
        [StringLength(150)]
        public string? LugarTrabajoM { get; set; }
    }
}
