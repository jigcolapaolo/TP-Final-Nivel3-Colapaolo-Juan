using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helper;
using System.IO;

namespace TPFinalNivel3_Colapaolo
{
    public partial class Perfil : System.Web.UI.Page
    {
        bool check { get; set; }
        User usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
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

                if (Validacion.IsValidEmail(txtEmail.Text))
                {
                    usuario.Email = txtEmail.Text;
                }
                else
                {
                    Session.Add("Error", "Formato de email incorrecto.");
                    Response.Redirect("Informe.aspx");
                }

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                if (passCheck.Checked)
                {
                    if (txtPassword.Text == usuario.Pass)
                    {
                        if (txtNuevaPass.Text.Length < 3)
                        {
                            Session.Add("Error", "La nueva Password debe tener mínimo 3 caracteres.");
                            Response.Redirect("Informe.aspx");
                        }
                        else
                            usuario.Pass = txtNuevaPass.Text;
                    }
                    else
                    {
                        Session.Add("Error", "La Password actual ingresada no es correcta.");
                        Response.Redirect("Informe.aspx");
                    }
                }


                string ruta = Server.MapPath("./ImagenPerfil/");
                string patronBusqueda = "p-" + usuario.Id + "*.jpg";
                string fecha = DateTime.Now.ToString("ddMMyyyyHHmmss");
                string[] archivosEncontrados = Directory.GetFiles(ruta, patronBusqueda);

                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {
                    //Elimina todas las imagenes anteriores que pudo tener este articulo y luego guarda la nueva.
                    foreach (string archivo in archivosEncontrados)
                    {
                        File.Delete(archivo);
                    }

                    txtImagen.PostedFile.SaveAs(ruta + "p-" + usuario.Id + fecha + ".jpg");
                    //GUARDO EL URL DE ESTA IMAGEN
                    usuario.UrlImagenPerfil = "p-" + usuario.Id + fecha + ".jpg";
                }

                UserNegocio negocio = new UserNegocio();
                negocio.actualizar(usuario);

                Response.Redirect("Perfil.aspx");

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void passCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (passCheck.Checked)
            {
                lblCheck.CssClass = "btn btn-sm btn-warning rounded-pill";
                divPassword.Attributes["class"] = "input-group mt-3";
                divNuevaPass.Attributes["class"] = "input-group mt-3 mb-5";

            }
            else
            {
                lblCheck.CssClass = "btn btn-sm btn-outline-success rounded-pill";
                divPassword.Attributes["class"] = "input-group mt-3 d-none";
                divNuevaPass.Attributes["class"] = "input-group mt-3 mb-5 d-none";
            }
        }
    }
}