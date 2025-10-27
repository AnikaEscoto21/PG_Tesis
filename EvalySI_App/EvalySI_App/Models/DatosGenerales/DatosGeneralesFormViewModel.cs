using System.Collections.Generic;

namespace EvalySI_App.Models.DatosGenerales
{
    public class DatosGeneralesFormViewModel
    {
        public CandidatoViewModel Candidato { get; set; }
        public PadresViewModel Padres { get; set; }
        public List<HermanoViewModel> Hermanos { get; set; }
        public List<HijoViewModel> Hijos { get; set; }

        public DatosGeneralesFormViewModel()
        {
            Candidato = new CandidatoViewModel();
            Padres = new PadresViewModel();
            Hermanos = new List<HermanoViewModel>();
            Hijos = new List<HijoViewModel>();
        }
    }
}
