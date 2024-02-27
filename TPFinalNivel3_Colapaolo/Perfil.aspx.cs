using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helper;

namespace TPFinalNivel3_Colapaolo
{
    public partial class Perfil : System.Web.UI.Page
    {
        User usuario {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
                Response.Redirect("Index.aspx", false);
            else
                usuario = (User)Session["user"];


            if (!IsPostBack)
            {
                txtEmail.Text = usuario.Email;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                imgRegistro.ImageUrl = Validacion.validarImagenPerfil(usuario);

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = (User)Session["user"];

                usuario.Email = txtEmail.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}