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

                    dgvArticulos.DataSource = Session["lista"];
                    dgvArticulos.DataBind();

                    dgvArticulosSm.DataSource = Session["lista"];
                    dgvArticulosSm.DataBind();
                }

            }

            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listar();
            dgvArticulos.DataBind();

            dgvArticulosSm.DataSource = negocio.listar();
            dgvArticulosSm.DataBind();
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ArticuloNegocio negocioArt = new ArticuloNegocio();

            dgvArticulos.DataSource = negocioArt.listar();
            dgvArticulos.PageIndex = e.NewPageIndex; /*Establece el índice de página de la GridView al nuevo valor*/
            //proporcionado en e.NewPageIndex.

            dgvArticulos.DataBind();              /*Vuelve a enlazar los datos a la GridView. Este paso es necesario después */
            //de cambiar el índice de página para asegurarse de que la GridView muestre los 
            //datos correspondientes a la nueva página.

            dgvArticulosSm.DataSource = negocioArt.listar();
            dgvArticulosSm.PageIndex = e.NewPageIndex;
            dgvArticulosSm.DataBind();

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();           /*AL CAMBIAR DE DATA KEY AL CLICKEAR EL EMOJI EN ACCION, GUARDA EL ID DE LA FILA SELECCIONADA*/
            Response.Redirect("DetalleArticulo.aspx?id=" + id, false);
        }

        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                Response.Redirect("DetalleArticulo.aspx?id=" + id + "&returnUrl=" + Server.UrlEncode(Request.Url.ToString()));
            }
            else if (e.CommandName == "Eliminar")
            {
                Session["idEliminar"] = id;

                ScriptManager.RegisterStartupScript(this, GetType(), "AbrirModal", "AbrirModal();", true);
            }
        }

        protected void btnModalEliminar_Click(object sender, EventArgs e)
        {
            if (Session["idEliminar"] == null)
            {
                Session.Add("Error", "No ha Seleccionado ningún Artículo");
                Response.Redirect("Informe.aspx", false);
            }
            else
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.eliminar((int)Session["idEliminar"]);

                dgvArticulos.DataSource = negocio.listar();
                dgvArticulos.DataBind();

                dgvArticulosSm.DataSource = negocio.listar();
                dgvArticulosSm.DataBind();

                Session.Remove("idEliminar");

                ScriptManager.RegisterStartupScript(this, GetType(), "CerrarModal", "CerrarModal();", true);
            }
        }

        protected void btnModalCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("idEliminar");
            ScriptManager.RegisterStartupScript(this, GetType(), "CerrarModal", "CerrarModal();", true);

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Session.Remove("idEliminar");
            ScriptManager.RegisterStartupScript(this, GetType(), "CerrarModal", "CerrarModal();", true);

        }
    }
}