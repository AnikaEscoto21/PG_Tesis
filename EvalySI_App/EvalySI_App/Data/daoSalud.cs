using EvalySI_App.Models.Salud;
using EvalySI_App.Models.Legal;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoSalud
    {
        //Conexión a la base de datos
        private readonly string _connectionString;

        public daoSalud(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para agregar historia médica de los candidatos
        public async Task<int> InsertarHistoriaMedicaAsync(HistoriaMedicaViewModel historia)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_HistoriaMedica", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", historia.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@CondicionGeneral", historia.CondicionGeneral ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@MalestarActual", historia.MalestarActual ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@HoraUltimaComida", historia.HoraUltimaComida ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@HorasDormidasAyer", historia.HorasDormidasAyer ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Embarazo", historia.Embarazo));
                    cmd.Parameters.Add(new SqlParameter("@EnfermedadGrave", historia.EnfermedadGrave ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar condiciones médicas de los candidatos
        public async Task<int> InsertarHistoriaMedicaCondAsync(HistoriaMedicaCondViewModel condicion)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_HistoriaMedicaCond", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", condicion.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@CondicionNombre", condicion.CondicionNombre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Especificar", condicion.Especificar ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Fecha",!string.IsNullOrWhiteSpace(condicion.Fecha) && DateTime.TryParse(condicion.Fecha, out DateTime fecha)? (object)fecha: DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar medicamentos de los candidatos
        public async Task<int> InsertarMedicamentosAsync(MedicamentosViewModel medicamentos)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Medicamentos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", medicamentos.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@IngestaAlcohol24h", medicamentos.IngestaAlcohol24h));
                    cmd.Parameters.Add(new SqlParameter("@Droga30dias", medicamentos.Droga30dias));
                    cmd.Parameters.Add(new SqlParameter("@TratMedicoReciente", medicamentos.TratMedicoReciente));
                    cmd.Parameters.Add(new SqlParameter("@ConsumeMedicamentos", medicamentos.ConsumeMedicamentos));
                    cmd.Parameters.Add(new SqlParameter("@DopingPracticado", medicamentos.DopingPracticado));
                    cmd.Parameters.Add(new SqlParameter("@DopingAlterado", medicamentos.DopingAlterado));
                    cmd.Parameters.Add(new SqlParameter("@Cirugia", medicamentos.Cirugia));
                    cmd.Parameters.Add(new SqlParameter("@AlergiaMedicamento", medicamentos.AlergiaMedicamento));
                    cmd.Parameters.Add(new SqlParameter("@UltimoChequeoMedico", medicamentos.UltimoChequeoMedico ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@AlergiaComida", medicamentos.AlergiaComida));
                    cmd.Parameters.Add(new SqlParameter("@UltimoChequeoOdonto", medicamentos.UltimoChequeoOdonto ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UltimoChequeoOftalmo", medicamentos.UltimoChequeoOftalmo ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UsaLentes", medicamentos.UsaLentes));
                    cmd.Parameters.Add(new SqlParameter("@Fuma", medicamentos.Fuma));
                    cmd.Parameters.Add(new SqlParameter("@Observaciones", medicamentos.Observaciones ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar hábitos de alcohol de los candidatos
        public async Task<int> InsertarHabitosAlcoholAsync(HabitosAlcoholViewModel habitos)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_HabitosAlcohol", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", habitos.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@UltimaVezBebio", habitos.UltimaVezBebio ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PromedioMensual", habitos.PromedioMensual ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ExcesosPorAnio", habitos.ExcesosPorAnio ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ComoEsCuandoExcede", habitos.ComoEsCuandoExcede ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UltimaAmnesia", habitos.UltimaAmnesia ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UltimaConduccionEbrio", habitos.UltimaConduccionEbrio ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PeorEvento", habitos.PeorEvento ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PeleaAlBeber", habitos.PeleaAlBeber));
                    cmd.Parameters.Add(new SqlParameter("@DetenidoAlBeber", habitos.DetenidoAlBeber));
                    cmd.Parameters.Add(new SqlParameter("@TratamientoControlBeber", habitos.TratamientoControlBeber));
                    cmd.Parameters.Add(new SqlParameter("@LaboroEbrioResaca", habitos.LaboroEbrioResaca));
                    cmd.Parameters.Add(new SqlParameter("@FaltoPorBeber", habitos.FaltoPorBeber));
                    cmd.Parameters.Add(new SqlParameter("@BebioEnHorasTrabajo", habitos.BebioEnHorasTrabajo));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar información de drogas de los candidatos
        public async Task<int> InsertarDrogasAsync(DrogasViewModel drogas)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Drogas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", drogas.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@UltimaVezConsumo", drogas.UltimaVezConsumo ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ProboDrogas", drogas.ProboDrogas));
                    cmd.Parameters.Add(new SqlParameter("@CualquierContacto", drogas.CualquierContacto));
                    cmd.Parameters.Add(new SqlParameter("@GuardoDrogaAjena", drogas.GuardoDrogaAjena));
                    cmd.Parameters.Add(new SqlParameter("@ContactoConVendedores", drogas.ContactoConVendedores));
                    cmd.Parameters.Add(new SqlParameter("@FamiliarConsume", drogas.FamiliarConsume));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}