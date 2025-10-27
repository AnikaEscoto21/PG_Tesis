using EvalySI_App.Models.Economia;
using EvalySI_App.Models.Informacion;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoEconomia
    {
        //Conexión a la base de datos
        private readonly string _connectionString;

        public daoEconomia(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para agregar cuentas bancarias de los candidatos
        public async Task<int> InsertarCuentaBancariaAsync(CuentaBancariaViewModel cuenta)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_CuentasBancarias", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", cuenta.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@Banco", cuenta.Banco ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TipoCuenta", cuenta.TipoCuenta ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Saldo", cuenta.Saldo ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar deudas de los candidatos
        public async Task<int> InsertarDeudaAsync(DeudaViewModel deuda)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Deudas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", deuda.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@Banco", deuda.Banco ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@MontoMensual", deuda.MontoMensual ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Razon", deuda.Razon ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar tarjetas de crédito de los candidatos
        public async Task<int> InsertarTarjetaCreditoAsync(TarjetaCreditoViewModel tarjeta)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_TarjetasCredito", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", tarjeta.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@Banco", tarjeta.Banco ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@LimiteCredito", tarjeta.LimiteCredito ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@SaldoActual", tarjeta.SaldoActual ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para agregar gastos mensuales de los candidatos
        public async Task<int> InsertarGastoMensualAsync(GastoMensualViewModel gasto)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_GastoMensual", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", gasto.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@ConceptoNombre", gasto.NombreConcepto));
                    cmd.Parameters.Add(new SqlParameter("@EsIngreso", gasto.EsIngreso));
                    cmd.Parameters.Add(new SqlParameter("@Monto", gasto.Monto));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> InsertarVehiculoAsync(VehiculoViewModel vehiculo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_Vehiculos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", vehiculo.CandidatoId));
                    cmd.Parameters.Add(new SqlParameter("@Marca", vehiculo.Marca ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", vehiculo.Modelo ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Placas", vehiculo.Placas ?? (object)DBNull.Value));

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para obtener todos los conceptos de gastos
        public async Task<List<GastoConceptoViewModel>> ObtenerConceptosGastosAsync()
        {
            var conceptos = new List<GastoConceptoViewModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_GastoConcepto", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            conceptos.Add(new GastoConceptoViewModel
                            {
                                IdGastoC = reader.GetInt32(reader.GetOrdinal("IdGastoC")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre"))
                            });
                        }
                    }
                }
            }

            return conceptos;
        }
    }
}