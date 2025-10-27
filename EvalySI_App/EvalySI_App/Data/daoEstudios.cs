using EvalySI_App.Models.Informacion;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoEstudios
    {
        //Conexión a la base de datos
        private readonly string _connectionString;

        public daoEstudios(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para agregar los estudios de los candidatos
        public async Task<int> InsertarEstudioAsync(EstudioViewModel estudio)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Estudio", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", estudio.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@NombreInstitucion", estudio.NombreInstitucion));
                    cmd.Parameters.Add(new SqlParameter("@EstudiosRealizados", estudio.EstudiosRealizados));
                    cmd.Parameters.Add(new SqlParameter("@Lugar", estudio.Lugar ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FechaDesde", estudio.FechaDesde ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FechaHasta", estudio.FechaHasta ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UltimoGrado", estudio.UltimoGrado ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}