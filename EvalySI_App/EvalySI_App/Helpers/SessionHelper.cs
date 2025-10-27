using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace EvalySI_App.Helpers
{
    public static class SessionHelper
    {
        // Método para guardar un objeto en la sesión
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Método para recuperar un objeto de la sesión
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
