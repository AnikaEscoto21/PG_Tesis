using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.DatosGenerales
{
    public class CandidatoViewModel
    {
        public int Id { get; set; }

        public DateTime FechaRegistro { get; set; }

        //Nombre
        [Required(ErrorMessage ="El campo Nombres es obligatorio")]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        //Edad
        [Required(ErrorMessage = "El campo Edad es obligatorio")]
        [Range(0, 99)]
        public int? Edad { get; set; }

        //DPI
        [Required(ErrorMessage = "El campo DPI es obligatorio")]
        [MaxLength(13)]
        public string? DPI { get; set; }

        [Required(ErrorMessage = "El campo DPI extendido en es obligatorio")]
        [StringLength(15)] 
        public string? DPIExtendidoEn { get; set; }

        //Nacimiento
        [StringLength(120)] 
        public string? LugarNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Fecha de nacimiento es obligatorio")]
        public DateTime? FechaNacimiento { get; set; }

        //Direccion actual
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        [StringLength(200)]
        public string? Direccion { get; set; }

        //Nacionalidad
        [Required(ErrorMessage = "El campo Nacionalidad es obligatorio")]
        [StringLength(60)]
        public string? Nacionalidad { get; set; }

        //IGSS
        [StringLength(20)]
        public string? NumIGSS { get; set; }

        //Telefonos
        [StringLength(8)]
        public string? TelefonoCasa { get; set; }

        [Required(ErrorMessage = "El campo Telefono Celular es obligatorio")]
        [StringLength(8)]
        public string? TelefonoCelular { get; set; }

        // Datos laborales
        [Required(ErrorMessage = "El campo Profesion es obligatorio")]
        [StringLength(120)]
        public string? Profesion { get; set; }

        [Required(ErrorMessage = "El campo Plaza a la que Aplica es obligatorio")]
        [StringLength(120)]
        public string? PlazaAplica { get; set; }

        //Info
        [Required(ErrorMessage = "El campo Estado Civil es obligatorio")]
        [StringLength(120)]
        public string? EstadoCivil { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Sangre es obligatorio")]
        [StringLength(8)]
        public string? TipoSangre { get; set; }

        // Emergencia
        [Required(ErrorMessage = "El campo Contacto de Emergencia es obligatorio")]
        [StringLength(8)]
        public string? ContactoEmergencia { get; set; }

        [Required(ErrorMessage = "El campo Telefono de Emergencia es obligatorio")]
        [StringLength(8)]
        public string? TelefonoEmergencia { get; set; }

        //Dependencia económica
        [StringLength(50)]
        public string? DependientesEconomicos { get; set; }

        //NIT
        [StringLength(9)]
        public string? Nit{ get; set; }

        //Informacion polígrafo
        [StringLength(100)]
        public string? ExperienciasPoligraficas { get; set; }

        [StringLength(60)]
        public string? ResultadoPoligrafoPrevio { get; set; }

        //Ingles
        [Range(0, 100)] 
        public byte? PorcentajeIngles { get; set; }

        //Correo y Redes
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [StringLength(255), EmailAddress] 
        public string? Correo { get; set; }

        [StringLength(150)] 
        public string? UsuariosRedes { get; set; }

        //Conyuge
        [StringLength(120)]
        public string? ConyugeNombre { get; set; }

        [Range(0, 99)]
        public int? ConyugeEdad { get; set; }

        [StringLength(120)]
        public string? ConyugeDPI { get; set; }

        [StringLength(200)]
        public string? ConyugeCel { get; set; }

        [StringLength(40)]
        public string? ConyugeEstadoCivil { get; set; }

        [StringLength(120)]
        public string? ConyugeOcupacion { get; set; }

        [StringLength(200)]
        public string? ConyugeTrabajo { get; set; }

        [StringLength(25)]
        public string? ConyugeTelTrabajo { get; set; }

    }
}
