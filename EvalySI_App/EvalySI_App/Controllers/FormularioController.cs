using EvalySI_App.Models.Formulario;
using Microsoft.AspNetCore.Mvc;
using EvalySI_App.Helpers;
using EvalySI_App.Data;
using Microsoft.Data.SqlClient;

namespace EvalySI_App.Controllers
{
    public class FormularioController : Controller
    {
        private const string SessionKeyForm = "_FormularioPoligrafo";
        private readonly IConfiguration _configuration;

        // Inyectar todos los DAOs
        private readonly daoDatosGenerales _daoDatosGenerales;
        private readonly daoEstudios _daoEstudios;
        private readonly daoHistorialLaboral _daoHistorialLaboral;
        private readonly daoEconomia _daoEconomia;
        private readonly daoSalud _daoSalud;
        private readonly daoLegal _daoLegal;
        private readonly daoPsicologia _daoPsicologia;
        private readonly daoConclusiones _daoConclusiones;

        public FormularioController(
            IConfiguration configuration,
            daoDatosGenerales daoDatosGenerales,
            daoEstudios daoEstudios,
            daoHistorialLaboral daoHistorialLaboral,
            daoEconomia daoEconomia,
            daoSalud daoSalud,
            daoLegal daoLegal,
            daoPsicologia daoPsicologia,
            daoConclusiones daoConclusiones)
        {
            _configuration = configuration;
            _daoDatosGenerales = daoDatosGenerales;
            _daoEstudios = daoEstudios;
            _daoHistorialLaboral = daoHistorialLaboral;
            _daoEconomia = daoEconomia;
            _daoSalud = daoSalud;
            _daoLegal = daoLegal;
            _daoPsicologia = daoPsicologia;
            _daoConclusiones = daoConclusiones;
        }

        // GET
        public IActionResult DatosGenerales()
        {
            // Recupera el modelo que existe en la sesión o se crea uno nuevo si en dado caso no existe
            var model = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm) ?? new FormularioPoligrafoViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DatosGenerales(FormularioPoligrafoViewModel modelFromView)
        {
            // VALIDAR QUE LOS CAMPOS REQUERIDOS VENGAN LLENOS
            if (string.IsNullOrWhiteSpace(modelFromView.Candidato?.Nombres) ||
                string.IsNullOrWhiteSpace(modelFromView.Candidato?.Apellidos) ||
                string.IsNullOrWhiteSpace(modelFromView.Candidato?.DPI))
            {
                ModelState.AddModelError("", "Los campos Nombres, Apellidos y DPI son obligatorios");
                return View(modelFromView);
            }

            var modelInSession = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm) ?? new FormularioPoligrafoViewModel();

            // Actualiza los datos generales 
            modelInSession.Candidato = modelFromView.Candidato;
            modelInSession.Padres = modelFromView.Padres;
            modelInSession.Hermanos = modelFromView.Hermanos;
            modelInSession.Hijos = modelFromView.Hijos;

            HttpContext.Session.Set(SessionKeyForm, modelInSession);

            // DEBUG: Verificar que se guardó
            var verificar = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            System.Diagnostics.Debug.WriteLine($"Guardado en sesión - Nombres: {verificar?.Candidato?.Nombres}");

            return RedirectToAction("Estudios");
        }

        // GET: 
        public IActionResult Estudios()
        {
            var model = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (model == null)
            {
                return RedirectToAction("DatosGenerales");
            }
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Estudios(FormularioPoligrafoViewModel modelFromView)
        {
            var modelInSession = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (modelInSession == null)
            {
                return RedirectToAction("DatosGenerales");
            }

            // Actualizar solo la información de los estudios
            modelInSession.Estudios = modelFromView.Estudios;

            HttpContext.Session.Set(SessionKeyForm, modelInSession);

            return RedirectToAction("HistorialLaboral");
        }

        // GET
        public IActionResult HistorialLaboral()
        {
            var model = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (model == null)
            {
                return RedirectToAction("DatosGenerales");
            }
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HistorialLaboral(FormularioPoligrafoViewModel modelFromView)
        {
            var modelInSession = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (modelInSession == null)
            {
                return RedirectToAction("DatosGenerales");
            }

            // Actualizar datos laborales
            modelInSession.HistorialLaboral = modelFromView.HistorialLaboral;
            modelInSession.LaboralPreguntas = modelFromView.LaboralPreguntas;
            modelInSession.ProcesoContratacion = modelFromView.ProcesoContratacion;

            HttpContext.Session.Set(SessionKeyForm, modelInSession);

            return RedirectToAction("Economia");
        }


        // GET
        public IActionResult Economia()
        {
            var model = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (model == null)
            {
                return RedirectToAction("DatosGenerales");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Economia(FormularioPoligrafoViewModel modelFromView)
        {
            var modelInSession = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (modelInSession == null)
            {
                return RedirectToAction("DatosGenerales");
            }

            // Actualiza la informacioón de la sección de economía
            modelInSession.CuentasBancarias = modelFromView.CuentasBancarias;
            modelInSession.TarjetasCredito = modelFromView.TarjetasCredito;
            modelInSession.Deudas = modelFromView.Deudas;
            modelInSession.Vehiculos = modelFromView.Vehiculos;

            HttpContext.Session.Set(SessionKeyForm, modelInSession);

            return RedirectToAction("Salud");
        }

        // GET
        public IActionResult Salud()
        {
            var model = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (model == null)
            {
                return RedirectToAction("DatosGenerales");
            }
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Salud(FormularioPoligrafoViewModel modelFromView)
        {
            var modelInSession = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (modelInSession == null)
            {
                return RedirectToAction("DatosGenerales");
            }

            // Actualiza las secciones de salud
            modelInSession.HistoriaMedica = modelFromView.HistoriaMedica;
            modelInSession.UsoMedicamentos = modelFromView.UsoMedicamentos;
            modelInSession.HabitosAlcohol = modelFromView.HabitosAlcohol;
            modelInSession.Drogas = modelFromView.Drogas;
            modelInSession.HistoriaMedicaConds = modelFromView.HistoriaMedicaConds;

            HttpContext.Session.Set(SessionKeyForm, modelInSession);

            return RedirectToAction("Legal");
        }

        // GET
        public IActionResult Legal()
        {
            var model = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (model == null)
            {
                return RedirectToAction("DatosGenerales");
            }
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Legal(FormularioPoligrafoViewModel modelFromView)
        {
            var modelInSession = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (modelInSession == null)
            {
                return RedirectToAction("DatosGenerales");
            }

            // Actualiza la información legal
            modelInSession.ActividadesDelictivas = modelFromView.ActividadesDelictivas;
            modelInSession.AntecedentesGenerales = modelFromView.AntecedentesGenerales;
            modelInSession.ManejoArmas = modelFromView.ManejoArmas;

            HttpContext.Session.Set(SessionKeyForm, modelInSession);

            return RedirectToAction("Psicologia");
        }

        // GET
        public IActionResult Psicologia()
        {
            var model = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (model == null)
            {
                return RedirectToAction("DatosGenerales");
            }
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Psicologia(FormularioPoligrafoViewModel modelFromView)
        {
            var modelInSession = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (modelInSession == null)
            {
                return RedirectToAction("DatosGenerales");
            }

            // Actualizar la información de psicologia
            modelInSession.AspectosEmocionales = modelFromView.AspectosEmocionales;
            modelInSession.HonestidadValores = modelFromView.HonestidadValores;
            modelInSession.InfoSocial = modelFromView.InfoSocial;

            HttpContext.Session.Set(SessionKeyForm, modelInSession);

            return RedirectToAction("Conclusion");
        }

        // GET
        public IActionResult Conclusion()
        {
            var model = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (model == null)
            {
                return RedirectToAction("DatosGenerales");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Conclusion(FormularioPoligrafoViewModel modelFromView)
        {
            var modelInSession = HttpContext.Session.Get<FormularioPoligrafoViewModel>(SessionKeyForm);
            if (modelInSession == null)
            {
                return RedirectToAction("Error", new { mensaje = "La sesión ha expirado" });
            }

            modelInSession.Conclusiones = modelFromView.Conclusiones;
            HttpContext.Session.Set(SessionKeyForm, modelInSession);

            try
            {
                await GuardarFormularioCompleto(modelInSession);
                HttpContext.Session.Remove(SessionKeyForm);
                return RedirectToAction("Exito");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { mensaje = ex.Message });
            }
        }

        // Vista de guardado correctamente 
        public IActionResult Exito()
        {
            return View();
        }

        public IActionResult Error(string mensaje)
        {
            ViewBag.MensajeError = mensaje;
            return View();
        }


        private async Task GuardarFormularioCompleto(FormularioPoligrafoViewModel model)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Usar una sola conexión y transacción para TODO
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Crear DAOs con la misma conexión y transacción
                        var daoDatosGen = new daoDatosGenerales(connectionString);
                        var daoEstudios = new daoEstudios(connectionString);
                        var daoLaboral = new daoHistorialLaboral(connectionString);
                        var daoEconomia = new daoEconomia(connectionString);
                        var daoSalud = new daoSalud(connectionString);
                        var daoLegal = new daoLegal(connectionString);
                        var daoPsicologia = new daoPsicologia(connectionString);
                        var daoConclusiones = new daoConclusiones(connectionString);

                        // 1. Guardar Candidato y obtener su ID
                        int candidatoId = await daoDatosGen.InsertarCandidatosAsync(model.Candidato);

                        // 2. Guardar Padres
                        if (model.Padres != null)
                        {
                            model.Padres.CandidatoId = candidatoId;
                            await daoDatosGen.InsertarPadreAsync(model.Padres);
                        }

                        // 3. Guardar Hermanos
                        if (model.Hermanos != null && model.Hermanos.Any())
                        {
                            foreach (var hermano in model.Hermanos)
                            {
                                hermano.CandidatoId = candidatoId;
                                await daoDatosGen.InsertarHermanosAsync(hermano);
                            }
                        }

                        // 4. Guardar Hijos
                        if (model.Hijos != null && model.Hijos.Any())
                        {
                            foreach (var hijo in model.Hijos)
                            {
                                hijo.CandidatoId = candidatoId;
                                await daoDatosGen.InsertarHijoAsync(hijo);
                            }
                        }

                        // 5. Guardar Estudios
                        if (model.Estudios != null && model.Estudios.Any())
                        {
                            foreach (var estudio in model.Estudios)
                            {
                                estudio.CandidatoId = candidatoId;
                                await daoEstudios.InsertarEstudioAsync(estudio);
                            }
                        }

                        // 6. Guardar Historial Laboral
                        if (model.HistorialLaboral != null && model.HistorialLaboral.Any())
                        {
                            foreach (var empleo in model.HistorialLaboral)
                            {
                                empleo.CandidatoId = candidatoId;
                                await daoLaboral.InsertarHistorialLaboralAsync(empleo);
                            }
                        }

                        // 7. Guardar Preguntas Laborales
                        if (model.LaboralPreguntas != null)
                        {
                            model.LaboralPreguntas.CandidatoId = candidatoId;
                            await daoLaboral.InsertarPreguntasLaboralesAsync(model.LaboralPreguntas);
                        }

                        // 8. Guardar Proceso Contratación
                        if (model.ProcesoContratacion != null)
                        {
                            model.ProcesoContratacion.CandidatoId = candidatoId;
                            await daoLaboral.InsertarProcesoContratacionAsync(model.ProcesoContratacion);
                        }

                        // 9. Guardar Vehículos
                        if (model.Vehiculos != null && model.Vehiculos.Any())
                        {
                            foreach (var vehiculo in model.Vehiculos)
                            {
                                vehiculo.CandidatoId = candidatoId;
                                await daoEconomia.InsertarVehiculoAsync(vehiculo);
                            }
                        }

                        // 10. Guardar Info Social
                        if (model.InfoSocial != null)
                        {
                            model.InfoSocial.CandidatoId = candidatoId;
                            await daoPsicologia.InsertarInfoSocialAsync(model.InfoSocial);
                        }

                        // 11. Guardar Economía
                        if (model.CuentasBancarias != null && model.CuentasBancarias.Any())
                        {
                            foreach (var cuenta in model.CuentasBancarias)
                            {
                                cuenta.CandidatoId = candidatoId;
                                await daoEconomia.InsertarCuentaBancariaAsync(cuenta);
                            }
                        }

                        if (model.TarjetasCredito != null && model.TarjetasCredito.Any())
                        {
                            foreach (var tarjeta in model.TarjetasCredito)
                            {
                                tarjeta.CandidatoId = candidatoId;
                                await daoEconomia.InsertarTarjetaCreditoAsync(tarjeta);
                            }
                        }

                        if (model.Deudas != null && model.Deudas.Any())
                        {
                            foreach (var deuda in model.Deudas)
                            {
                                deuda.CandidatoId = candidatoId;
                                await daoEconomia.InsertarDeudaAsync(deuda);
                            }
                        }

                        if (model.GastosMensuales != null && model.GastosMensuales.Any())
                        {
                            foreach (var gasto in model.GastosMensuales)
                            {
                                gasto.CandidatoId = candidatoId;
                                await daoEconomia.InsertarGastoMensualAsync(gasto);
                            }
                        }

                        // 12. Guardar Salud
                        if (model.HistoriaMedica != null)
                        {
                            model.HistoriaMedica.CandidatoId = candidatoId;
                            await daoSalud.InsertarHistoriaMedicaAsync(model.HistoriaMedica);
                        }

                        if (model.UsoMedicamentos != null)
                        {
                            model.UsoMedicamentos.CandidatoId = candidatoId;
                            await daoSalud.InsertarMedicamentosAsync(model.UsoMedicamentos);
                        }

                        if (model.HabitosAlcohol != null)
                        {
                            model.HabitosAlcohol.CandidatoId = candidatoId;
                            await daoSalud.InsertarHabitosAlcoholAsync(model.HabitosAlcohol);
                        }

                        if (model.Drogas != null)
                        {
                            model.Drogas.CandidatoId = candidatoId;
                            await daoSalud.InsertarDrogasAsync(model.Drogas);
                        }

                        if (model.HistoriaMedicaConds != null && model.HistoriaMedicaConds.Any())
                        {
                            foreach (var condicion in model.HistoriaMedicaConds)
                            {
                                condicion.CandidatoId = candidatoId;
                                await daoSalud.InsertarHistoriaMedicaCondAsync(condicion);
                            }
                        }

                        // 13. Guardar Legal
                        if (model.ActividadesDelictivas != null)
                        {
                            model.ActividadesDelictivas.CandidatoId = candidatoId;
                            await daoLegal.InsertarActividadesDelictivasAsync(model.ActividadesDelictivas);
                        }

                        if (model.AntecedentesGenerales != null)
                        {
                            model.AntecedentesGenerales.CandidatoId = candidatoId;
                            await daoLegal.InsertarAntecedentesAsync(model.AntecedentesGenerales);
                        }

                        if (model.ManejoArmas != null)
                        {
                            model.ManejoArmas.CandidatoId = candidatoId;
                            await daoLegal.InsertarManejoArmasAsync(model.ManejoArmas);
                        }

                        // 14. Guardar Psicología
                        if (model.AspectosEmocionales != null)
                        {
                            model.AspectosEmocionales.CandidatoId = candidatoId;
                            await daoPsicologia.InsertarAspectosEmocionalesAsync(model.AspectosEmocionales);
                        }

                        if (model.HonestidadValores != null)
                        {
                            model.HonestidadValores.CandidatoId = candidatoId;
                            await daoPsicologia.InsertarValoresAsync(model.HonestidadValores);
                        }

                        // 15. Guardar Conclusiones
                        if (model.Conclusiones != null)
                        {
                            model.Conclusiones.CandidatoId = candidatoId;
                            await daoConclusiones.InsertarConclusionesAsync(model.Conclusiones);
                        }

                        // Si todo salió bien, confirmar la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Si hay algún error, revertir TODO
                        transaction.Rollback();

                        // Guardar el error en un archivo de log
                        await GuardarErrorEnArchivoAsync(ex, model);

                        // Re-lanzar la excepción para que el controlador la maneje
                        throw;
                    }
                }
            }
        }

        // Método para guardar errores en archivo
        private async Task GuardarErrorEnArchivoAsync(Exception ex, FormularioPoligrafoViewModel model)
        {
            try
            {
                string carpetaLogs = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

                // Crear carpeta si no existe
                if (!Directory.Exists(carpetaLogs))
                {
                    Directory.CreateDirectory(carpetaLogs);
                }

                string nombreArchivo = $"Error_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string rutaArchivo = Path.Combine(carpetaLogs, nombreArchivo);

                var contenido = new System.Text.StringBuilder();
                contenido.AppendLine("ERROR AL GUARDAR FORMULARIO ");
                contenido.AppendLine($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                contenido.AppendLine($"Candidato: {model.Candidato?.Nombres} {model.Candidato?.Apellidos}");
                contenido.AppendLine($"DPI: {model.Candidato?.DPI}");
                contenido.AppendLine();
                contenido.AppendLine(" DETALLES DEL ERROR ");
                contenido.AppendLine($"Mensaje: {ex.Message}");
                contenido.AppendLine($"Tipo: {ex.GetType().Name}");
                contenido.AppendLine();
                contenido.AppendLine(" STACK TRACE ");
                contenido.AppendLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    contenido.AppendLine();
                    contenido.AppendLine(" INNER EXCEPTION ");
                    contenido.AppendLine($"Mensaje: {ex.InnerException.Message}");
                    contenido.AppendLine(ex.InnerException.StackTrace);
                }

                await System.IO.File.WriteAllTextAsync(rutaArchivo, contenido.ToString());
            }
            catch
            {
            }
        }
    }
}

