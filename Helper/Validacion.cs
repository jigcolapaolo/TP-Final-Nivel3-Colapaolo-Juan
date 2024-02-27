using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace Helper
{
    public static class Validacion
    {
        public static string validarImagenPerfil(User user)
        {
            string url;

            if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                return url = user.UrlImagenPerfil.StartsWith("p-") ? "~/ImagenPerfil/" + user.UrlImagenPerfil : user.UrlImagenPerfil;
            else
                return "~/Images/Perfil.png";
        }

        public static bool IsValidEmail(string email)
        {
            // Patrón de expresión regular para verificar el formato de correo electrónico
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

    }
}
