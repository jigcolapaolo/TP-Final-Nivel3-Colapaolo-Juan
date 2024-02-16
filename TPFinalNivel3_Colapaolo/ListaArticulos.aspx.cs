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
    public partial class ListaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["lista"] == null)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Session.Add("lista", articuloNegocio.listar());
                }

                dgvArticulos.DataSource = Session["lista"];
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.DataSource = Session["lista"];
            dgvArticulos.PageIndex = e.NewPageIndex; /*Establece el índice de página de la GridView al nuevo valor*/
            //proporcionado en e.NewPageIndex.


            dgvArticulos.DataBind();              /*Vuelve a enlazar los datos a la GridView. Este paso es necesario después */
            //de cambiar el índice de página para asegurarse de que la GridView muestre los 
            //datos correspondientes a la nueva página.
        }
    }
}