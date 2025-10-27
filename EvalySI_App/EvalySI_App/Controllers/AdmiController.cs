using EvalySI_App.Data;
using EvalySI_App.Models.DatosGenerales;
using EvalySI_App.Models.Formulario;
using Microsoft.AspNetCore.Mvc;

namespace EvalySI_App.Controllers
{
    public class AdminController : Controller
    {
        private readonly daoAdmin _daoAdmin;
        private readonly ILogger<AdminController> _logger;

        public AdminController(daoAdmin daoAdmin, ILogger<AdminController> logger)
        {
            _daoAdmin = daoAdmin;
            _logger = logger;
        }

        // GET: Admin/Index - Listar todos los candidatos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var candidatos = await _daoAdmin.ListarCandidatosResumenAsync();
                _logger.LogInformation("Lista de candidatos obtenida correctamente. Total: {Count}", candidatos.Count);
                return View(candidatos ?? new List<CandidatoViewModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de candidatos");
                return View(new List<CandidatoViewModel>());
            }
        }

        // GET: Admin/Detalle/5 - Ver detalle completo de un candidato
        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            try
            {
                var formulario = await _daoAdmin.ObtenerDetalleCandidatoAsync(id);
                if (formulario == null || formulario.Candidato == null)
                {
                    _logger.LogWarning("Candidato con ID {Id} no encontrado", id);
                    return RedirectToAction("Index");
                }

                _logger.LogInformation("Detalle del candidato {Id} obtenido correctamente", id);
                return View(formulario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el detalle del candidato {Id}", id);
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Editar/5 - Formulario para editar candidato
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                var formulario = await _daoAdmin.ObtenerDetalleCandidatoAsync(id);
                if (formulario == null || formulario.Candidato == null)
                {
                    _logger.LogWarning("Candidato con ID {Id} no encontrado para editar", id);
                    return RedirectToAction("Index");
                }

                _logger.LogInformation("Formulario de edición cargado para candidato {Id}", id);
                return View(formulario.Candidato);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el formulario de edición para candidato {Id}", id);
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/Editar/5 - Guardar cambios del candidato
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(CandidatoViewModel candidato)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("Modelo inválido al intentar actualizar candidato {Id}", candidato.Id);
                    return View(candidato);
                }

                await _daoAdmin.ActualizarCandidatoAsync(candidato);
                
                _logger.LogInformation("Candidato {Id} actualizado correctamente", candidato.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar candidato {Id}", candidato.Id);
                return View(candidato);
            }
        }

        // POST: Admin/Eliminar/5 - Eliminar candidato (soft delete)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var formulario = await _daoAdmin.ObtenerDetalleCandidatoAsync(id);
                if (formulario == null || formulario.Candidato == null)
                {
                    _logger.LogWarning("Candidato con ID {Id} no encontrado para eliminar", id);
                    return RedirectToAction("Index");
                }

                await _daoAdmin.EliminarCandidatoAsync(id);

                _logger.LogInformation("Candidato {Id} eliminado correctamente", id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar candidato {Id}", id);
                return RedirectToAction("Index");
            }
        }
    }
}
