using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class User
    {
        public int Id { get; set; }
        public string Email {  get; set; }
        public string Pass {  get; set; }
        public string Nombre {  get; set; }
        public string Apellido {  get; set; }
        public string UrlImagenPerfil { get; set; }
        //1 es Admin
        public bool Admin { get; set; }

    }
}
