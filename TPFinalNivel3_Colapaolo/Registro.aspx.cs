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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
                Response.Redirect("Index.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                User usuario = new User();
                UserNegocio negocio = new UserNegocio();

                if (Validacion.IsValidEmail(txtEmail.Text))
                {
                    usuario.Email = txtEmail.Text;
                }
                else
                {
                    Session.Add("Error", "Formato de Email incorrecto.");
                    Response.Redirect("Informe.aspx");
                }

                if (txtPassword.Text == txtConfirmarPass.Text)
                {
                    usuario.Pass = txtConfirmarPass.Text;
                }
                else
                {
                    Session.Add("Error", "El Password no coincide.");
                    Response.Redirect("Informe.aspx");
                }

                usuario.Nombre = string.IsNullOrEmpty(txtNombre.Text) ? "" : txtNombre.Text;
                usuario.Apellido = string.IsNullOrEmpty(txtApellido.Text) ? "" : txtApellido.Text;

                //SELECCIONA LA UBICACION EN LA QUE ESTAMOS, SELECCIONA IMAGENPERFIL Y SE METE DENTRO
                string ruta = Server.MapPath("./ImagenPerfil/");
                string fecha = DateTime.Now.ToString("ddMMyyyyHHmmss");


                usuario.Id = negocio.nuevoUser(usuario);


                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {
                    //GUARDO LA IMAGEN QUE HE SELECCIONADO EN LA RUTA COMPLETA
                    txtImagen.PostedFile.SaveAs(ruta + "p-" + usuario.Id + fecha + ".jpg");
                    //GUARDO EL URL DE ESTA IMAGEN
                    usuario.UrlImagenPerfil = "p-" + usuario.Id + fecha + ".jpg";

                }
                else
                {
                    usuario.UrlImagenPerfil = "";
                }

                Session.Add("user", usuario);
                Session.Add("mensajeInforme", "Registro exitoso.");
                Response.Redirect("Informe.aspx?informe=" + true, false);


            }
            catch (Exception)
            {

                Session.Add("Error", "Error al ingresar los datos.");
                Response.Redirect("Informe.aspx", false);
            }
        }
    }
}