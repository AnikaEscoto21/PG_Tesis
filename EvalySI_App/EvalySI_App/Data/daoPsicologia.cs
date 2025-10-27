using EvalySI_App.Models.Informacion;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoPsicologia
    {
        //Conexión a la base de datos
        private readonly string _connectionString;

        public daoPsicologia(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para agregar los datos de los aspectos emocionales de los candidatos
        public async Task<int> InsertarAspectosEmocionalesAsync(AspectosEmocionalesViewModel aspectos)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_AspectosEmocionales", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", aspectos.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@VivenPadres", aspectos.VivenPadres));
                    cmd.Parameters.Add(new SqlParameter("@RelacionEntrePadres", aspectos.RelacionEntrePadres ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConQuienVive", aspectos.ConQuienVive ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@IntentosSuicidio", aspectos.IntentosSuicidio ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@CualidadRespeta", aspectos.CualidadRespeta ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DefectoIntolerable", aspectos.DefectoIntolerable ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@MejorExperiencia", aspectos.MejorExperiencia ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PeorExperiencia", aspectos.PeorExperiencia ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar los datos de los valores de los candidatos
        public async Task<int> InsertarValoresAsync(ValoresViewModel valores)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_HonestidadValores", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", valores.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@HonestaIdentidad", valores.HonestaIdentidad));
                    cmd.Parameters.Add(new SqlParameter("@DocumentoFalsoEnPlaza", valores.DocumentoFalsoEnPlaza));
                    cmd.Parameters.Add(new SqlParameter("@ManejoValores", valores.ManejoValores));
                    cmd.Parameters.Add(new SqlParameter("@Faltantes", valores.Faltantes));
                    cmd.Parameters.Add(new SqlParameter("@Sobrantes", valores.Sobrantes));
                    cmd.Parameters.Add(new SqlParameter("@PrestamosConDineroACargo", valores.PrestamosConDineroACargo));
                    cmd.Parameters.Add(new SqlParameter("@ManejoInfoConf", valores.ManejoInfoConf));
                    cmd.Parameters.Add(new SqlParameter("@UsoIndebidoInfoConf", valores.UsoIndebidoInfoConf));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar información social de los candidatos
        public async Task<int> InsertarInfoSocialAsync(InformacionSocialViewModel infoSocial)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_InfoSocial", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", infoSocial.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@Religion", infoSocial.Religion ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FrecuenciaCulto", infoSocial.FrecuenciaCulto ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Grupos", infoSocial.Grupos ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ActividadesTiempoLibre", infoSocial.ActividadesTiempoLibre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Autodescripcion", infoSocial.Autodescripcion ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Piercings", infoSocial.Piercings ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Tatuajes", infoSocial.Tatuajes ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TatuajesDescripcion", infoSocial.TatuajesDescripcion ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}