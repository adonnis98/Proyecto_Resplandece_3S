using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Proyecto_Resplandece.Clases
{
    public static class SeguridadUtils
    {
        public static bool VerificarContrasena(string contrasenaIngresada, string hashAlmacenado, string saltAlmacenado)
        {
            string hashLimpio = hashAlmacenado.Trim();
            return contrasenaIngresada == hashLimpio;
        }

        public static void GenerarHashSalt(string contrasena, out string hash, out string salt)
        {
            // 1. Guardamos la contraseña simple en la variable 'hash'
            hash = contrasena;

            // 2. Guardamos un valor estático en 'salt'
            salt = "NO_USADO";
        }
    }
}

