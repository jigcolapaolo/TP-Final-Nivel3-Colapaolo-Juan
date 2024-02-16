using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Helper
{
    public static class Validacion
    {
        public static string validarImagen(User user)
        {
            if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                return user.UrlImagenPerfil;
            else
                return "~/Images/Perfil.png";
        }
    }
}
