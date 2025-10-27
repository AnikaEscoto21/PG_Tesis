using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using EvalySI_App.Data;
using EvalySI_App.Models.Usuarios;

namespace EvalySI_App.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly daoLogin _dao;

        public LoginController(ILogger<LoginController> logger, daoLogin dao)
        {
            _logger = logger;
            _dao = dao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }

                // ✅ Llamada correcta a método NO estático
                var usuarioModel = await _dao.ValidarUsuarioAsync(model.Email, model.Password);

                if (usuarioModel == null)
                {
                    _logger.LogWarning("Intento de login fallido para email: {Email}", model.Email);
                    ModelState.AddModelError(string.Empty, "Correo electrónico o contraseña incorrectos.");
                    return View("Index", model);
                }

                // Crear sesión
                HttpContext.Session.SetString("UsuarioId", usuarioModel.IdUsuario.ToString());
                HttpContext.Session.SetString("UsuarioNombre", usuarioModel.Nombre);
                HttpContext.Session.SetString("UsuarioEmail", usuarioModel.Email);

                _logger.LogInformation("Usuario {Email} ha iniciado sesión correctamente", model.Email);
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar el login para email: {Email}", model?.Email);
                ModelState.AddModelError(string.Empty, "Error al procesar la solicitud. Inténtalo nuevamente.");
                return View("Index", model);
            }
        }

        // Acción para cerrar sesión
        public IActionResult Logout()
        {
            try
            {
                // Obtener el email del usuario antes de cerrar sesión para el log
                var usuarioEmail = HttpContext.Session.GetString("UsuarioEmail");

                // Limpiar toda la sesión
                HttpContext.Session.Clear();

                _logger.LogInformation("Usuario {Email} ha cerrado sesión", usuarioEmail ?? "Desconocido");

                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cerrar sesión");
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
