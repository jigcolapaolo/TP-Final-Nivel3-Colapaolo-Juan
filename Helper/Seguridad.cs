using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Helper
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            User usuario = user != null ? (User)user : null;

            if (usuario != null && usuario.Id != 0)
            {
                return true;
            }

            return false;
        }

        public static bool isAdmin(object user)
        {
            User usuario = user != null ? (User)user : null;

            if (usuario != null && usuario.Admin)
                return true;
            else
                return false;
        }
    }
}
