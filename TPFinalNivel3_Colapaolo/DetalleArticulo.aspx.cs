using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

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

                    //Cargo datos
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
            }
        }
    }
}