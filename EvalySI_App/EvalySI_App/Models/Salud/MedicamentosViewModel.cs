using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Salud
{
    public class MedicamentosViewModel
    {
        [Required]
        public int CandidatoId { get; set; }

        public bool IngestaAlcohol24h { get; set; }

        public bool Droga30dias { get; set; }

        public bool TratMedicoReciente { get; set; }

        public bool ConsumeMedicamentos { get; set; }

        public bool DopingPracticado { get; set; } = false;

        public bool DopingAlterado { get; set; } = false;

        public bool Cirugia { get; set; } = false;

        public bool AlergiaMedicamento { get; set; } = false;

        [StringLength(40)] 
        public string? UltimoChequeoMedico { get; set; }

        public bool AlergiaComida { get; set; }

        [StringLength(40)] 
        public string? UltimoChequeoOdonto { get; set; }

        [StringLength(40)] 
        public string? UltimoChequeoOftalmo { get; set; }

        public bool UsaLentes { get; set; }

        public bool Fuma { get; set; }

        [StringLength(200)] 
        public string? Observaciones { get; set; }
    }
}
