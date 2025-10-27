using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Legal
{
    public class ActividadesDelictivasViewModel
    {
        [Required] 
        public int CandidatoId { get; set; }    

        public bool AsociadoConDelincuentes { get; set; } = false;

        public bool ConoceDelincuentes { get; set; } = false;

        public bool DetenidoCuestionado { get; set; } = false;

        public bool EstuvoRecluso { get; set; } = false;

        public bool HizoAlgoDetenido { get; set; } = false;

        public bool FamiliarDetenido { get; set; } = false;

        public bool CargosPorFaltas { get; set; } = false;

        public bool PenalesPoliciacosLimpios { get; set; } = false;

        public bool AyudoCometerDelito { get; set; } = false;

        public bool CambioPrecios { get; set; } = false;

        public bool UsoIlegalTarjeta { get; set; } = false;

        public bool DocumentoFalsificado { get; set; } = false;

        public bool RoboArticulo { get; set; } = false;

        public bool CompraVentaAutosRobados { get; set; } = false;

        public bool ActoSIlegal { get; set; } = false;

        public bool AcosoS { get; set; } = false;

        public bool PG { get; set; } = false;

        public bool BeneficiosPros { get; set; } = false;

        public bool Secuestro { get; set; } = false;

        public bool OtraActividadIllicita { get; set; } = false;
    }
}
