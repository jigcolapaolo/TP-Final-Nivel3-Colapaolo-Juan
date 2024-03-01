using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helper;
using System.Security.Policy;
using System.Net;
using System.Web.UI.HtmlControls;

namespace TPFinalNivel3_Colapaolo
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public List<Marca> listaMarcas { get; set; }
        public List<Categoria> listaCategoria { get; set; }

        public User user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //SI LA PAGINA NO ES DEFAULT NI LOGIN NI REGISTROTRAINEE, REDIRIGE A LOGIN.ASPX, NO PERMITE ACCEDER A LAS OTRAS PAGINAS
            //    HASTA LOGUEARSE

            if (!(Page is Default || Page is Login1 || Page is Registro || Page is DetalleArticulo))
            {
                if (!Seguridad.sesionActiva(Session["user"]))
                {
                    //Si no hay una sesion activa, redirige a login
                    Response.Redirect("Login.aspx", false);
                }
            }


            if (!IsPostBack)
            {
                //Cargo las listas de Categoria y Marca en el Sidebar
                if (listaMarcas == null)
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
                    imgPerfil.ImageUrl = Validacion.validarImagenPerfil(user);


                    //Boton Registrarse y Login
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

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void chkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            string idCat = "";

            foreach (RepeaterItem item in repeaterCategoria.Items)
            {
                var chkCategoria = item.FindControl("chkCategoria") as CheckBox;
                var lblIdCat = item.FindControl("lblIdCat") as Label;

                if (chkCategoria.Checked && chk == chkCategoria)
                {
                    idCat = lblIdCat.Text;
                }

            }

            if (idCat != "")
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                if (Page is Favoritos)
                {
                    user = (User)Session["user"];
                    Session["favoritosFiltrados"] = negocio.filtroFavoritos(user.Id, "Categoria", idCat);
                    Response.Redirect("Favoritos.aspx");
                }
                else
                {
                    Session["articulosFiltrados"] = negocio.filtro(idCat, "", "Categoria");
                    Response.Redirect("Index.aspx");
                }

            }

        }

        protected void chkMarca_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            string idMarca = "";

            foreach (RepeaterItem item in repeaterMarcas.Items)
            {
                var chkMarca = item.FindControl("chkMarca") as CheckBox;
                var lblIdMarca = item.FindControl("lblIdMarca") as Label;

                if (chkMarca.Checked && chk == chkMarca)
                {
                    idMarca = lblIdMarca.Text;
                }

            }

            if (idMarca != "")
            {

                ArticuloNegocio negocio = new ArticuloNegocio();

                if (Page is Favoritos)
                {
                    user = (User)Session["user"];
                    Session["favoritosFiltrados"] = negocio.filtroFavoritos(user.Id, "Marca", idMarca);
                    Response.Redirect("Favoritos.aspx");
                }
                else
                {
                    Session["articulosFiltrados"] = negocio.filtro(idMarca, "", "Marca");
                    Response.Redirect("Index.aspx");
                }

            }
        }

        protected void btnTodosArt_Click(object sender, EventArgs e)
        {
            Session["articulosFiltrados"] = null;
            Session["favoritosFiltrados"] = null;

            if (Page is Favoritos)
                Response.Redirect("Favoritos.aspx");
            else
                Response.Redirect("Index.aspx");
        }

        protected void chkArtBarato_CheckedChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (Page is Favoritos)
            {
                user = (User)Session["user"];
                Session["favoritosFiltrados"] = negocio.filtroFavoritos(user.Id, "Precio", "Mas Barato");
                Response.Redirect("Favoritos.aspx");
            }
            else
            {
                Session["articulosFiltrados"] = negocio.filtro("Mas Barato", "", "Precio");
                Response.Redirect("Index.aspx");
            }

        }

        protected void chkArtCaro_CheckedChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (Page is Favoritos)
            {
                user = (User)Session["user"];
                Session["favoritosFiltrados"] = negocio.filtroFavoritos(user.Id, "Precio", "Mas Caro");
                Response.Redirect("Favoritos.aspx");
            }
            else
            {
                Session["articulosFiltrados"] = negocio.filtro("Mas Caro", "", "Precio");
                Response.Redirect("Index.aspx");
            }
        }
    }
}