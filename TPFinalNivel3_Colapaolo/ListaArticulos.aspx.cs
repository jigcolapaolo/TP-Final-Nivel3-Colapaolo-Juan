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
            if (!Seguridad.isAdmin(Session["user"]))
                Response.Redirect("Index.aspx");

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

            if (Session["listaFiltrada"] == null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.listar();
                dgvArticulos.DataBind();

                dgvArticulosSm.DataSource = negocio.listar();
                dgvArticulosSm.DataBind();
            }
            else
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = Session["listaFiltrada"];
                dgvArticulos.DataBind();

                dgvArticulosSm.DataSource = Session["listaFiltrada"];
                dgvArticulosSm.DataBind();
            }
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ArticuloNegocio negocioArt = new ArticuloNegocio();

            if (Session["listaFiltrada"] == null)
            {

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
            else
            {
                dgvArticulos.DataSource = Session["listaFiltrada"];
                dgvArticulos.PageIndex = e.NewPageIndex;
                dgvArticulos.DataBind();


                dgvArticulosSm.DataSource = Session["listaFiltrada"];
                dgvArticulosSm.PageIndex = e.NewPageIndex;
                dgvArticulosSm.DataBind();
            }

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

        protected void btnAgregarSm_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleArticulo.aspx?returnUrl=" + Server.UrlEncode(Request.Url.ToString()));
        }

        protected void btnAgregarLg_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleArticulo.aspx?returnUrl=" + Server.UrlEncode(Request.Url.ToString()));
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Mayor a..");
                ddlCriterio.Items.Add("Menor a..");
                ddlCriterio.Items.Add("Igual a..");

                divFiltro.Visible = true;
            }
            else if (ddlCampo.SelectedItem.ToString() == "Marca")
            {
                MarcaNegocio negocioMarca = new MarcaNegocio();

                ddlCriterio.DataSource = negocioMarca.listar();
                ddlCriterio.DataValueField = "Id";
                ddlCriterio.DataTextField = "Descripcion";
                ddlCriterio.DataBind();

                divFiltro.Visible = false;

            }
            else if (ddlCampo.SelectedItem.ToString() == "Categoria")
            {
                CategoriaNegocio negocioCat = new CategoriaNegocio();

                ddlCriterio.DataValueField = "Id";
                ddlCriterio.DataSource = negocioCat.listar();
                ddlCriterio.DataTextField = "Descripcion";
                ddlCriterio.DataBind();

                divFiltro.Visible = false;
            }
            else
            {
                ddlCriterio.Items.Add("Empieza con..");
                ddlCriterio.Items.Add("Termina con..");
                ddlCriterio.Items.Add("Contiene..");

                divFiltro.Visible = true;
            }


        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            Session["listaFiltrada"] = null;
            Response.Redirect("ListaArticulos.aspx");
        }

        protected void btnBuscara_Click(object sender, EventArgs e)
        {

            if (((ddlCampo.SelectedItem.ToString() != "Marca" && ddlCampo.SelectedItem.ToString() != "Categoria") && txtFiltroAdmin.Text == "") || ddlCriterio.Items.Count == 1)
            {
                divError.Attributes["class"] = "text-danger my-2 h6";
                lblError.Text = "Debe seleccionar un Campo, un Criterio y completar el Filtro.";
            }
            else
            {
                divError.Attributes["class"] = "text-danger my-2 d-none h6";

                string criterio;
                string filtro;

                if (ddlCampo.SelectedItem.ToString() == "Marca" || ddlCampo.SelectedItem.ToString() == "Categoria")
                {
                    criterio = ddlCriterio.SelectedValue.ToString();
                    filtro = "";
                }
                else
                {
                    criterio = ddlCriterio.SelectedItem.ToString();
                    filtro = txtFiltroAdmin.Text;
                }
                string campo = ddlCampo.SelectedItem.ToString();


                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> lista = negocio.filtro(criterio, filtro, campo);

                dgvArticulos.DataSource = lista;
                dgvArticulos.DataBind();

                dgvArticulosSm.DataSource = lista;
                dgvArticulosSm.DataBind();

                Session["listaFiltrada"] = lista;
            }

        }
    }
}