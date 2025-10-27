using EvalySI_App.Models.Legal;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoLegal
    {
        //Conexión a la base de datos
        private readonly string _connectionString;

        public daoLegal(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para agregar actividades delictivas de los candidatos
        public async Task<int> InsertarActividadesDelictivasAsync(ActividadesDelictivasViewModel actividades)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_ActividadesDelictivas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", actividades.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@AsociadoConDelincuentes", actividades.AsociadoConDelincuentes));
                    cmd.Parameters.Add(new SqlParameter("@ConoceDelincuentes", actividades.ConoceDelincuentes));
                    cmd.Parameters.Add(new SqlParameter("@DetenidoCuestionado", actividades.DetenidoCuestionado));
                    cmd.Parameters.Add(new SqlParameter("@EstuvoRecluso", actividades.EstuvoRecluso));
                    cmd.Parameters.Add(new SqlParameter("@HizoAlgoDetenido", actividades.HizoAlgoDetenido));
                    cmd.Parameters.Add(new SqlParameter("@FamiliarDetenido", actividades.FamiliarDetenido));
                    cmd.Parameters.Add(new SqlParameter("@CargosPorFaltas", actividades.CargosPorFaltas));
                    cmd.Parameters.Add(new SqlParameter("@PenalesPoliciacosLimpios", actividades.PenalesPoliciacosLimpios));
                    cmd.Parameters.Add(new SqlParameter("@AyudoCometerDelito", actividades.AyudoCometerDelito));
                    cmd.Parameters.Add(new SqlParameter("@CambioPrecios", actividades.CambioPrecios));
                    cmd.Parameters.Add(new SqlParameter("@UsoIlegalTarjeta", actividades.UsoIlegalTarjeta));
                    cmd.Parameters.Add(new SqlParameter("@DocumentoFalsificado", actividades.DocumentoFalsificado));
                    cmd.Parameters.Add(new SqlParameter("@RoboArticulo", actividades.RoboArticulo));
                    cmd.Parameters.Add(new SqlParameter("@CompraVentaAutosRobados", actividades.CompraVentaAutosRobados));
                    cmd.Parameters.Add(new SqlParameter("@ActoSIlegal", actividades.ActoSIlegal));
                    cmd.Parameters.Add(new SqlParameter("@AcosoS", actividades.AcosoS));
                    cmd.Parameters.Add(new SqlParameter("@PG", actividades.PG));
                    cmd.Parameters.Add(new SqlParameter("@BeneficiosPros", actividades.BeneficiosPros));
                    cmd.Parameters.Add(new SqlParameter("@Secuestro", actividades.Secuestro));
                    cmd.Parameters.Add(new SqlParameter("@OtraActividadIllicita", actividades.OtraActividadIllicita));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar antecedentes de los candidatos
        public async Task<int> InsertarAntecedentesAsync(AntecedentesViewModel antecedentes)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Antecedentes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", antecedentes.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@CausoHeridasGraves", antecedentes.CausoHeridasGraves));
                    cmd.Parameters.Add(new SqlParameter("@MatoAlguien", antecedentes.MatoAlguien));
                    cmd.Parameters.Add(new SqlParameter("@UltimaRina", antecedentes.UltimaRina ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UltimaPerdidaControl", antecedentes.UltimaPerdidaControl ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar manejo de armas de los candidatos
        public async Task<int> InsertarManejoArmasAsync(ManejoArmasViewModel armas)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_ManejoArmas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", armas.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@TieneArmasPropias", armas.TieneArmasPropias));
                    cmd.Parameters.Add(new SqlParameter("@HaPortadoArma", armas.HaPortadoArma));
                    cmd.Parameters.Add(new SqlParameter("@EnfrentamientoConArma", armas.EnfrentamientoConArma));
                    cmd.Parameters.Add(new SqlParameter("@DisparoInnecesario", armas.DisparoInnecesario));
                    cmd.Parameters.Add(new SqlParameter("@UsoIndebidoArma", armas.UsoIndebidoArma));
                    cmd.Parameters.Add(new SqlParameter("@CompraVentaIlegalArmas", armas.CompraVentaIlegalArmas));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}