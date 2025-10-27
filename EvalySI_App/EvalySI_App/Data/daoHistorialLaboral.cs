using EvalySI_App.Models.Informacion;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoHistorialLaboral
    {
        //Conexión a la base de datos
        private readonly string _connectionString;

        public daoHistorialLaboral(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para agregar historial laboral de los candidatos
        public async Task<int> InsertarHistorialLaboralAsync(HistorialLaboralViewModel historial)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_HistorialLaboral", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", historial.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@Empresa", historial.Empresa));
                    cmd.Parameters.Add(new SqlParameter("@Cargo", historial.Cargo ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoEmpresa", historial.TelefonoEmpresa ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FechaIngreso", historial.FechaIngreso ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FechaEgreso", historial.FechaEgreso ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UltimoSalario", historial.UltimoSalario ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@CausaRetiro", historial.CausaRetiro ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@JefeInmediato", historial.JefeInmediato ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoJefe", historial.TelefonoJefe ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@CargoJefe", historial.CargoJefe ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Observaciones", historial.Observaciones ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }


        // Método para agregar preguntas laborales de los candidatos
        public async Task<int> InsertarPreguntasLaboralesAsync(PreguntasLaboralesViewModel preguntas)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_LaboralPreguntas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", preguntas.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@PedidoRenuncia", preguntas.PedidoRenuncia ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@AbandonoEmpleo", preguntas.AbandonoEmpleo ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@AcusadoDeshonestidad", preguntas.AcusadoDeshonestidad ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@VReglamentos", preguntas.VReglamentos ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@BeneficiosIlicitos", preguntas.BeneficiosIlicitos ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UsoIndebidoInfoConf", preguntas.UsoIndebidoInfoConf ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DiscusionesConSuperiores", preguntas.DiscusionesConSuperiores ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ActaAdmOProceso", preguntas.ActaAdmOProceso ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Sobornos", preguntas.Sobornos ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Sabotaje", preguntas.Sabotaje ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DemandaContra", preguntas.DemandaContra ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DemandaAAlguien", preguntas.DemandaAAlguien ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Observaciones", preguntas.Observaciones ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ProblemasLaborales", preguntas.ProblemasLaborales ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FaltasAdmSerias", preguntas.FaltasAdmSerias ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@OpinionSindicatos", preguntas.OpinionSindicatos ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }


        // Método para agregar proceso de contratación de los candidatos
        public async Task<int> InsertarProcesoContratacionAsync(ProcesoContratacionViewModel proceso)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_ProcesoContratacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", proceso.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@OcultoIdentidad", proceso.OcultoIdentidad ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@OmisionDeliberada", proceso.OmisionDeliberada ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DocumentoFalso", proceso.DocumentoFalso ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@InfoFalsaCV", proceso.InfoFalsaCV ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DocumentosEnOrden", proceso.DocumentosEnOrden ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Observaciones", proceso.Observaciones ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}