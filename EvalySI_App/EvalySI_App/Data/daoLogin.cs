using EvalySI_App.Models.Usuarios;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EvalySI_App.Data
{
    public class daoLogin
    {
        private readonly string _connectionString;

        public daoLogin(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UsuarioViewModel?> ValidarUsuarioAsync(string email, string password)
        {
            UsuarioViewModel? usuarioModel = null;

            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            // 
            await using var cmd = new SqlCommand("sp_Login", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            //
            var pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 255)
            {
                Value = (object?)email ?? DBNull.Value
            };
            var pHash = new SqlParameter("@HashPassword", SqlDbType.NVarChar, 255)
            {
                Value = (object?)password ?? DBNull.Value
            };

            cmd.Parameters.Add(pEmail);
            cmd.Parameters.Add(pHash);

            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                usuarioModel = new UsuarioViewModel
                {
                    IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                    FechaCreacion = reader.GetDateTime(reader.GetOrdinal("FechaCreacion"))
                };
            }

            return usuarioModel;
        }
    }
}
