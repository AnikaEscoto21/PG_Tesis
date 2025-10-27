using EvalySI_App.Models.Legal;
using EvalySI_App.Models.Salud;
using EvalySI_App.Models.DatosGenerales;
using EvalySI_App.Models.Economia;
using EvalySI_App.Models.Informacion;

namespace EvalySI_App.Models.Formulario
{
    public class FormularioPoligrafoViewModel
    {
        public CandidatoViewModel Candidato { get; set; } = new();
        public PadresViewModel? Padres { get; set; }
        public List<HermanoViewModel> Hermanos { get; set; } = new();
        public List<HijoViewModel> Hijos { get; set; } = new();

        public AspectosEmocionalesViewModel? AspectosEmocionales { get; set; }
        public InformacionSocialViewModel? InfoSocial { get; set; }
        public List<EstudioViewModel> Estudios { get; set; } = new();
        public ProcesoContratacionViewModel? ProcesoContratacion { get; set; }
        public List<HistorialLaboralViewModel> HistorialLaboral { get; set; } = new();
        public PreguntasLaboralesViewModel? LaboralPreguntas { get; set; }
        public ValoresViewModel? HonestidadValores { get; set; }

        public List<CuentaBancariaViewModel> CuentasBancarias { get; set; } = new();
        public List<TarjetaCreditoViewModel> TarjetasCredito { get; set; } = new();
        public List<GastoMensualViewModel> GastosMensuales { get; set; } = new();
        public List<DeudaViewModel> Deudas { get; set; } = new();
        public List<VehiculoViewModel> Vehiculos { get; set; } = new();

        public ActividadesDelictivasViewModel? ActividadesDelictivas { get; set; }
        public HistoriaMedicaViewModel? HistoriaMedica { get; set; }
        public List<HistoriaMedicaCondViewModel> HistoriaMedicaConds { get; set; } = new();
        public MedicamentosViewModel? UsoMedicamentos { get; set; }
        public AntecedentesViewModel? AntecedentesGenerales { get; set; }
        public ManejoArmasViewModel? ManejoArmas { get; set; }
        public HabitosAlcoholViewModel? HabitosAlcohol { get; set; }
        public DrogasViewModel? Drogas { get; set; }
        public ConclusionesViewModel? Conclusiones { get; set; }
    }
}
