using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Resplandece.Clases
{
    public static class SessionManager
    {
        public static int UserId { get; set; }
        public static string Username { get; set; } = string.Empty;
        public static string Rol { get; set; } = string.Empty;

        public static bool IsAdmin
        {
            get { return Rol.Equals("Administrador", System.StringComparison.OrdinalIgnoreCase); }
        }

        public static void Logout()
        {
            UserId = 0;
            Username = string.Empty;
            Rol = string.Empty;
        }
    }
}
