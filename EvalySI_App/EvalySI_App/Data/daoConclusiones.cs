using EvalySI_App.Models.Informacion;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoConclusiones
    {
        //Conexión a la base de datos
        private readonly string _connectionString;

        public daoConclusiones(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para agregar conclusiones de los candidatos
        public async Task<int> InsertarConclusionesAsync(ConclusionesViewModel conclusiones)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Conclusiones", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", conclusiones.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@ExperienciaChantajeable", conclusiones.ExperienciaChantajeable ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PensabaPreguntasFaltantes", conclusiones.PensabaPreguntasFaltantes ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FalseoOmisiones", conclusiones.FalseoOmisiones ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@AlgoQuePreocupe", conclusiones.AlgoQuePreocupe ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@AlgoQueDecir", conclusiones.AlgoQueDecir ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ObjetivosCP", conclusiones.ObjetivosCP ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ObjetivosMP", conclusiones.ObjetivosMP ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ObjetivosLP", conclusiones.ObjetivosLP ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}