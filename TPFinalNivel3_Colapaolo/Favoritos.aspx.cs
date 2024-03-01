using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Colapaolo
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulosFav { get; set; }
        public List<Articulo> FavoritosFiltrados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = Session["user"] != null ? (User)Session["user"] : null;

            if (user == null)
            {
                Response.Redirect("Index.aspx");
            }


            if (!IsPostBack)
            {

                if (ListaArticulosFav == null)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    ListaArticulosFav = negocio.listarFavoritos(user.Id);
                }

                repRepeaterFav.DataSource = ListaArticulosFav;
                repRepeaterFav.DataBind();

            }

            if (Session["favoritosFiltrados"] != null)
            {

                if (Session["favoritosFiltradosB"] != Session["favoritosFiltrados"])
                {
                    repRepeaterFav.DataSource = Session["favoritosFiltrados"];
                    repRepeaterFav.DataBind();

                    Session["favoritosFiltradosB"] = Session["favoritosFiltrados"];
                }
            }

            if (Session["favoritosFiltrados"] != null)
                FavoritosFiltrados = (List<Articulo>)Session["favoritosFiltrados"];

            if (ListaArticulosFav != null && FavoritosFiltrados != null)
            {
                if (FavoritosFiltrados.Count == 0 || ListaArticulosFav.Count == 0)
                {
                    divSinArticulos.Attributes["class"] = "d-flex justify-content-center cursorDefault";
                }
                else
                {
                    divSinArticulos.Attributes["class"] = "d-none";
                }
            }
        }

        //Boton que itera sobre los elementos(Articulos Favoritos) del repeater, comprueba si los checkbox estan checked,
        //si no lo estan, busca el control de ese objeto que guarda su Id en Text.
        //Finalmente para eliminar ese elemento de la lista de favoritos, uso como parametros el id del usuario actual y el id
        //de cada objeto con Checked="false". Para terminar cargo de vuelta la lista.

        protected void btnLinkActualizar_Click(object sender, EventArgs e)
        {
            User user = Session["user"] != null ? (User)Session["user"] : null;

            foreach (RepeaterItem item in repRepeaterFav.Items)
            {

                CheckBox chkFavorito = (CheckBox)item.FindControl("chkFavorito");

                if (!chkFavorito.Checked)
                {
                    Label lblId = (Label)item.FindControl("lblId");
                    string id = lblId.Text;
                    int intId = Convert.ToInt32(id);

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminarFavorito(user.Id, intId);
                }

            }

            if (ListaArticulosFav == null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                ListaArticulosFav = negocio.listarFavoritos(user.Id);
            }

            repRepeaterFav.DataSource = ListaArticulosFav;
            repRepeaterFav.DataBind();
        }

        protected void txtFiltroNombreFav_TextChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            User user = (User)Session["user"];

            string criterio = "Nombre";
            string filtro = txtFiltroNombreFav.Text;
            List<Articulo> listaFav = negocio.filtroFavoritos(user.Id, criterio, filtro);

            repRepeaterFav.DataSource = listaFav;
            repRepeaterFav.DataBind();

            if (listaFav.Count == 0)
            {
                divSinArticulos.Attributes["class"] = "d-flex justify-content-center cursorDefault";
            }
            else
            {
                divSinArticulos.Attributes["class"] = "d-none";
            }
        }

        protected void chkFavorito_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in repRepeaterFav.Items)
            {
                CheckBox chkFavorito = (CheckBox)item.FindControl("chkFavorito");
                Label lblStar = (Label)item.FindControl("lblStar");
                Label lblId = (Label)item.FindControl("lblId");

                if (chkFavorito.Checked)
                {
                    lblStar.CssClass = "form-check-label bi bi-star-fill";
                }
                else
                {
                    lblStar.CssClass = "form-check-label bi bi-star";
                }
            }

        }
    }
}