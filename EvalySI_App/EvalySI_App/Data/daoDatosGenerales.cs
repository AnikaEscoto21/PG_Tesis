using EvalySI_App.Models;
using EvalySI_App.Models.DatosGenerales;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoDatosGenerales
    {
        //Conexión a la base de datos
        private readonly string _connectionString;

        public daoDatosGenerales(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<bool> ExisteDPIAsync(string dpi)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Candidatos WHERE DPI = @DPI", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@DPI", dpi));
                    int count = (int)await cmd.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

        public async Task<int> InsertarCandidatosAsync(CandidatoViewModel candidato)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Candidato", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nombres", candidato.Nombres));
                    cmd.Parameters.Add(new SqlParameter("@Apellidos", candidato.Apellidos));
                    cmd.Parameters.Add(new SqlParameter("@Edad", candidato.Edad));
                    cmd.Parameters.Add(new SqlParameter("@DPI", string.IsNullOrWhiteSpace(candidato.DPI) ? DBNull.Value : candidato.DPI));
                    cmd.Parameters.Add(new SqlParameter("@DPIExtendidoEn", string.IsNullOrWhiteSpace(candidato.DPIExtendidoEn) ? DBNull.Value : candidato.DPIExtendidoEn));
                    cmd.Parameters.Add(new SqlParameter("@LugarNacimiento", candidato.LugarNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", candidato.FechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", candidato.Direccion ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Nacionalidad", candidato.Nacionalidad ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@NumIGSS", candidato.NumIGSS ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoCasa", candidato.TelefonoCasa ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoCelular", candidato.TelefonoCelular ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Profesion", candidato.Profesion ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PlazaAplica", candidato.PlazaAplica ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@EstadoCivil", candidato.EstadoCivil ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TipoSangre", candidato.TipoSangre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ContactoEmergencia", candidato.ContactoEmergencia ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoEmergencia", candidato.TelefonoEmergencia ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DependientesEconomicos", candidato.DependientesEconomicos));
                    cmd.Parameters.Add(new SqlParameter("@NIT", string.IsNullOrWhiteSpace(candidato.Nit) ? DBNull.Value : candidato.Nit));
                    cmd.Parameters.Add(new SqlParameter("@ExperienciasPoligraficas", candidato.ExperienciasPoligraficas ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ResultadoPoligrafoPrevio", candidato.ResultadoPoligrafoPrevio ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PorcentajeIngles", candidato.PorcentajeIngles));
                    cmd.Parameters.Add(new SqlParameter("@Correo", string.IsNullOrWhiteSpace(candidato.Correo) ? DBNull.Value : candidato.Correo));
                    cmd.Parameters.Add(new SqlParameter("@UsuariosRedes", candidato.UsuariosRedes ?? (object)DBNull.Value));

                    // Datos del cónyuge
                    cmd.Parameters.Add(new SqlParameter("@ConyugeNombre", candidato.ConyugeNombre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeEdad", candidato.ConyugeEdad));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeCel", candidato.ConyugeCel ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeDPI", candidato.ConyugeDPI ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeEstadoCivil", candidato.ConyugeEstadoCivil ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeOcupacion", candidato.ConyugeOcupacion ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeTrabajo", candidato.ConyugeTrabajo ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeTelTrabajo", candidato.ConyugeTelTrabajo ?? (object)DBNull.Value));

                    // Ejecutar y leer el resultado
                    var result = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }

        // Método para agregar los datos de los hermanos de los candidatos 
        public async Task<int> InsertarHermanosAsync(HermanoViewModel hermano)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Hermano", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", hermano.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", hermano.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Edad", hermano.Edad.HasValue ? (object)hermano.Edad.Value : DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@NoResidencia", string.IsNullOrWhiteSpace(hermano.NoResidencia) ? DBNull.Value : hermano.NoResidencia));
                    cmd.Parameters.Add(new SqlParameter("@Dpi", string.IsNullOrWhiteSpace(hermano.DPI) ? DBNull.Value : hermano.DPI));
                    cmd.Parameters.Add(new SqlParameter("@EstadoCivil",string.IsNullOrWhiteSpace(hermano.EstadoCivil) ? DBNull.Value : hermano.EstadoCivil));
                    cmd.Parameters.Add(new SqlParameter("@Celular", string.IsNullOrWhiteSpace(hermano.Celular) ? DBNull.Value : hermano.Celular));
                    cmd.Parameters.Add(new SqlParameter("@Profesion", string.IsNullOrWhiteSpace(hermano.Profesion) ? DBNull.Value : hermano.Profesion));
                    cmd.Parameters.Add(new SqlParameter("@Nacionalidad", string.IsNullOrWhiteSpace(hermano.Nacionalidad) ? DBNull.Value : hermano.Nacionalidad));
                    cmd.Parameters.Add(new SqlParameter("@LugarTrabajo", string.IsNullOrWhiteSpace(hermano.LugarTrabajo) ? DBNull.Value : hermano.LugarTrabajo));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar los datos de los hijos de los candidatos 
        public async Task<int> InsertarHijoAsync(HijoViewModel hijo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Hijos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", hijo.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@NombreHijo", hijo.NombreHijo));
                    cmd.Parameters.Add(new SqlParameter("@EdadHijo",hijo.EdadHijo));
                    cmd.Parameters.Add(new SqlParameter("@EstadoCivilHijo", hijo.EstadoCivilHijo));
                    cmd.Parameters.Add(new SqlParameter("@Direccion",hijo.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Ocupacion", hijo.Ocupacion));
                    cmd.Parameters.Add(new SqlParameter("@Nacionalidad", hijo.Nacionalidad));
                    cmd.Parameters.Add(new SqlParameter("@LugarTrabajo", hijo.LugarTrabajo));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar los datos de los padres de los candidatos 
        public async Task<int> InsertarPadreAsync(PadresViewModel padre)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Padres", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", padre.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@NombrePadre", padre.NombrePadre)); 
                    cmd.Parameters.Add(new SqlParameter("@NombreMadre", padre.NombreMadre)); 
                    cmd.Parameters.Add(new SqlParameter("@EdadP", padre.EdadPadre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@EdadM", padre.EdadMadre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@NoResidenciaP", padre.NumResidenciaP ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@NoResidenciaM", padre.NumResidenciaM ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DPIP", padre.DPIPadre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DPIM", padre.DPIMadre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@EstadoCivilP", padre.EstadoCivilP ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@EstadoCivilM", padre.EstadoCivilM ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@CelularP", padre.CelularP ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@CelularM", padre.CelularM ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ProfesionP", padre.ProfesionP ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ProfesionM", padre.ProfesionM ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@NacionalidadP", padre.NacionalidadP ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@NacionalidadM", padre.NacionalidadM ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@LugarTrabajoP", padre.LugarTrabajoP ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@LugarTrabajoM", padre.LugarTrabajoM ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
