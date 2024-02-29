using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helper;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Reflection.Emit;
using Label = System.Web.UI.WebControls.Label;
using System.Web.DynamicData;

namespace TPFinalNivel3_Colapaolo
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ListaArticulos == null)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    ListaArticulos = negocio.listar();

                }

                if (Session["articulosFiltrados"] == null)
                {
                    repRepeater.DataSource = ListaArticulos;
                    repRepeater.DataBind();

                }
                else
                {
                    repRepeater.DataSource = Session["articulosFiltrados"];
                    repRepeater.DataBind();
                }

            }

            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session["listaFavoritos"] = negocio.listarFavoritos(user.Id);

                if (!IsPostBack)
                {
                    if (Session["articulosFiltrados"] == null)
                    {
                        repRepeater.DataSource = ListaArticulos;
                        repRepeater.DataBind();
                    }
                    else
                    {
                        repRepeater.DataSource = Session["articulosFiltrados"];
                        repRepeater.DataBind();
                    }

                }

            }


        }

        protected void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            string criterio = "Nombre";
            string filtro = txtFiltroNombre.Text;
            List<Articulo> lista = negocio.filtro(criterio, filtro, "", true);

            repRepeater.DataSource = lista;
            repRepeater.DataBind();



        }

        protected void chkFavoritoIndex_CheckedChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            User user = (User)Session["user"];
            List<Articulo> listaFavoritos = (List<Articulo>)Session["listaFavoritos"];

            foreach (RepeaterItem item in repRepeater.Items)
            {
                CheckBox chkFavoritoIndex = (CheckBox)item.FindControl("chkFavoritoIndex");
                Label lblStarIndex = (Label)item.FindControl("lblStarIndex");
                Label lblIdIndex = (Label)item.FindControl("lblIdIndex");

                if (chkFavoritoIndex.Checked)
                {
                    lblStarIndex.CssClass = "form-check-label bi bi-star-fill";
                    if (!listaFavoritos.Any(articulo => articulo.Id == int.Parse(lblIdIndex.Text)))
                        negocio.agregarFavorito(user.Id, int.Parse(lblIdIndex.Text));
                    Session["listaFavoritos"] = negocio.listarFavoritos(user.Id);
                }
                else
                {
                    lblStarIndex.CssClass = "form-check-label bi bi-star";
                    negocio.eliminarFavorito(user.Id, int.Parse(lblIdIndex.Text));
                    Session["listaFavoritos"] = negocio.listarFavoritos(user.Id);
                }
            }

            List<Articulo> lista = negocio.listar();
            repRepeater.DataSource = lista;
            repRepeater.DataBind();
        }

        protected void repRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["listaFavoritos"] != null)
            {


                List<Articulo> listaFavoritos = (List<Articulo>)Session["listaFavoritos"];

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    // Obtener el Id del artículo actual
                    int idArticulo = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Id"));
                    CheckBox chkFavoritoIndex = e.Item.FindControl("chkFavoritoIndex") as CheckBox;

                    bool estaEnFavoritos = listaFavoritos.Any(articulo => articulo.Id == idArticulo);
                    // Verificar si el Id está en la lista de favoritos
                    if (estaEnFavoritos)
                    {

                        Label icon = e.Item.FindControl("lblStarIndex") as Label;
                        icon.CssClass = "form-check-label bi bi-star-fill";
                        chkFavoritoIndex.Checked = true;
                    }
                    else
                    {
                        Label icon = e.Item.FindControl("lblStarIndex") as Label;
                        icon.CssClass = "form-check-label bi bi-star";
                        chkFavoritoIndex.Checked = false;
                    }
                }
            }
        }
    }
}