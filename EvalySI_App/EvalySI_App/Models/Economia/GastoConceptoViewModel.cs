using System.ComponentModel.DataAnnotations;

namespace EvalySI_App.Models.Economia
{
    public class GastoConceptoViewModel
    {
        public int IdGastoC { get; set; }

        [Required, StringLength(80)] 
        public string Nombre { get; set; } = string.Empty;
    }

    public class GastoMensualViewModel
    {
        public int IdGM { get; set; }

        [Required] 
        public int CandidatoId { get; set; }

        [Required] 
        public string NombreConcepto { get; set; }

        public bool EsIngreso { get; set; }

        [Range(0, double.MaxValue)] 
        public decimal Monto { get; set; }
    }

}
