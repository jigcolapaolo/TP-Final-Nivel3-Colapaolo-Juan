using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Helper;
using System.Globalization;

namespace TPFinalNivel3_Colapaolo
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocioArt = new ArticuloNegocio();

            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    List<Articulo> listaArticulos = negocioArt.listar();
                    Articulo articulo = listaArticulos.Find(x => x.Id == id);

                    if (!Seguridad.isAdmin(Session["user"]))
                    {


                        //Cargo datos en modo User
                        if (string.IsNullOrEmpty(articulo.ImagenUrl))
                            imgArticulo.ImageUrl = "./Images/SinImagen.png";
                        else
                            imgArticulo.ImageUrl = articulo.ImagenUrl;

                        lblNombre.Text = articulo.Nombre;
                        lblMarca.Text = articulo.Marca.Descripcion;
                        lblCategoria.Text = articulo.Categoria.Descripcion;
                        lblPrecio.Text = "$" + articulo.Precio.ToString();
                        lblDescripcion.Text = articulo.Descripcion;
                    }
                    else
                    {
                        //Cargo datos en modo Admin
                        if (string.IsNullOrEmpty(articulo.ImagenUrl))
                            imgArticuloAdmin.ImageUrl = "./Images/SinImagen.png";
                        else
                            imgArticuloAdmin.ImageUrl = articulo.ImagenUrl;

                        txtCodigo.Text = articulo.Codigo;
                        txtNombre.Text = articulo.Nombre;
                        txtPrecio.Text = string.Format(CultureInfo.InvariantCulture, "{0:G}", articulo.Precio);
                        txtDescripcion.Text = articulo.Descripcion;

                        CategoriaNegocio negocioCat = new CategoriaNegocio();
                        MarcaNegocio negocioMarca = new MarcaNegocio();

                        ddlCategoria.DataSource = negocioCat.listar();
                        ddlCategoria.DataValueField = "Id";
                        ddlCategoria.DataTextField = "Descripcion";
                        ddlCategoria.DataBind();
                        ddlMarca.DataSource = negocioMarca.listar();
                        ddlMarca.DataValueField = "Id";
                        ddlMarca.DataTextField = "Descripcion";
                        ddlMarca.DataBind();

                        ddlCategoria.SelectedValue = articulo.Categoria.Id.ToString();
                        ddlMarca.SelectedValue = articulo.Marca.Id.ToString();

                    }


                }
            }
        }
    }
}