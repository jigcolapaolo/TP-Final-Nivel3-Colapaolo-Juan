using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Colapaolo
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulosFav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Index.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (ListaArticulosFav == null)
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();

                        ListaArticulosFav = negocio.listarFavoritos(((User)Session["user"]).Id);
                    }

                    repRepeaterFav.DataSource = ListaArticulosFav;
                    repRepeaterFav.DataBind();
                }
            }
        }
    }
}