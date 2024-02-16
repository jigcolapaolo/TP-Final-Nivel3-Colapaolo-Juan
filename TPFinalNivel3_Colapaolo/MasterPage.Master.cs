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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public List<Marca> listaMarcas { get; set; }
        public List<Categoria> listaCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo las listas de Categoria y Marca en el Sidebar
                if(listaMarcas == null)
                {
                    MarcaNegocio negocioMar = new MarcaNegocio();
                    CategoriaNegocio negocioCat = new CategoriaNegocio();
                    listaMarcas = negocioMar.listar();
                    listaCategoria = negocioCat.listar();
                }

                repeaterMarcas.DataSource = listaMarcas;
                repeaterMarcas.DataBind();
                repeaterCategoria.DataSource = listaCategoria;
                repeaterCategoria.DataBind();

                //Cargo los datos con Sesion Abierta

                if (Seguridad.sesionActiva(Session["user"]))
                {
                    User user = (User)Session["user"];

                    //Imagen
                    imgPerfil.Visible = true;
                    imgPerfil.ImageUrl = user.UrlImagenPerfil;

                    //Boton Logout, Registrarse y Login
                    btnLogout.Visible = true;
                    btnRegistrarse.Visible = false;
                    btnLogin.Visible = false;



                    //Label Bienvenido
                    string nombreUser = !string.IsNullOrEmpty(user.Nombre) ? user.Nombre.ToString() : "";
                    lblBienvenido.Text = nombreUser != "" ? "Bienvenido, " + nombreUser + "!" : "Bienvenido!";
                }
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void modalBtnLogout_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Session.Clear();
                Response.Redirect("Index.aspx", false);
            }
        }
    }
}