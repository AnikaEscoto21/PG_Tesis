using EvalySI_App.Data;
using EvalySI_App.Models.Formulario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EvalySI_App.Controllers
{
    public class DatosGeneralesController : Controller
    {
        private readonly daoDatosGenerales _daoDatosGenerales;
        private readonly string _connectionString;

        public DatosGeneralesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _daoDatosGenerales = new daoDatosGenerales(_connectionString);
        }

        // GET: DatosGenerales/Crear
        public IActionResult Crear()
        {
            var viewModel = new FormularioPoligrafoViewModel();
            return View(viewModel);
        }

        // POST: DatosGenerales/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(FormularioPoligrafoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // 1. Insertar el candidato y obtener su ID
                    int candidatoId = await _daoDatosGenerales.InsertarCandidatosAsync(model.Candidato);

                    // Asignar el ID del candidato a las entidades relacionadas y guardarlas
                    if (model.Padres != null)
                    {
                        model.Padres.CandidatoId = candidatoId;
                        await _daoDatosGenerales.InsertarPadreAsync(model.Padres);
                    }

                    if (model.Hermanos != null)
                    {
                        foreach (var hermano in model.Hermanos)
                        {
                            hermano.CandidatoId = candidatoId;
                            await _daoDatosGenerales.InsertarHermanosAsync(hermano);
                        }
                    }

                    if (model.Hijos != null)
                    {
                        foreach (var hijo in model.Hijos)
                        {
                            hijo.CandidatoId = candidatoId;
                            await _daoDatosGenerales.InsertarHijoAsync(hijo);
                        }
                    }

                    // Aquí iría la lógica para insertar las otras partes del formulario si las agregas a daoDatosGenerales.

                    return RedirectToAction("Index", "Home"); // Redirigir a una página de éxito o al inicio
                }
                catch (System.Exception ex)
                {
                    // Manejar el error
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar los datos: " + ex.Message);
                }
            }

            // Si el modelo no es válido, se vuelve a mostrar el formulario con los errores
            return View(model);
        }
    }
}
