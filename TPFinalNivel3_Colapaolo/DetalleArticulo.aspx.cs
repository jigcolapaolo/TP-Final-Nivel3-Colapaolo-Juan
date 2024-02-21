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
using System.Security.Cryptography.X509Certificates;

namespace TPFinalNivel3_Colapaolo
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public bool vistaAdmin { get; set; }
        public Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocioArt = new ArticuloNegocio();

            if (!IsPostBack)
            {

                if (Session["vistaAdmin"] == null)
                    Session.Add("vistaAdmin", vistaAdmin = true);

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    List<Articulo> listaArticulos = negocioArt.listar();
                    articulo = listaArticulos.Find(x => x.Id == id);
                    Session.Add("articulo", articulo);
                    articulo = (Articulo)Session["articulo"];

                    

                }
            }

            if (!Seguridad.isAdmin(Session["user"]))
            {
                articulo = (Articulo)Session["articulo"];

                //Cargo datos en modo sin o con User
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
                articulo = (Articulo)Session["articulo"];

                //Cargo datos en modo Admin (VistaAdmin)
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


                //Cargo datos en modo Admin (VistaUser)
                if (string.IsNullOrEmpty(articulo.ImagenUrl))
                    imgArticuloAdminUser.ImageUrl = "./Images/SinImagen.png";
                else
                    imgArticuloAdminUser.ImageUrl = articulo.ImagenUrl;

                lblNombreAdmin.Text = articulo.Nombre;
                lblMarcaAdmin.Text = articulo.Marca.Descripcion;
                lblCategoriaAdmin.Text = articulo.Categoria.Descripcion;
                lblPrecioAdmin.Text = "$" + articulo.Precio.ToString();
                lblDescripcionAdmin.Text = articulo.Descripcion;
            }
        }

        protected void linkVista_Click(object sender, EventArgs e)
        {
            articulo = (Articulo)Session["articulo"];

            if ((bool)Session["vistaAdmin"] == true)
                Session["vistaAdmin"] = false;
            else
                Session["vistaAdmin"] = true;

            if (Convert.ToBoolean(Session["vistaAdmin"]) == true)
            {
                //Cargo datos en modo Admin (VistaAdmin)
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
            else
            {
                //Cargo datos en modo Admin (VistaUser)
                if (string.IsNullOrEmpty(articulo.ImagenUrl))
                    imgArticuloAdminUser.ImageUrl = "./Images/SinImagen.png";
                else
                    imgArticuloAdminUser.ImageUrl = articulo.ImagenUrl;

                lblNombreAdmin.Text = articulo.Nombre;
                lblMarcaAdmin.Text = articulo.Marca.Descripcion;
                lblCategoriaAdmin.Text = articulo.Categoria.Descripcion;
                lblPrecioAdmin.Text = "$" + articulo.Precio.ToString();
                lblDescripcionAdmin.Text = articulo.Descripcion;
            }

        }

        protected void linkVistaAdmin_Click(object sender, EventArgs e)
        {
            articulo = (Articulo)Session["articulo"];

            if ((bool)Session["vistaAdmin"] == true)
                Session["vistaAdmin"] = false;
            else
                Session["vistaAdmin"] = true;

            if (Convert.ToBoolean(Session["vistaAdmin"]) == true)
            {
                //Cargo datos en modo Admin (VistaAdmin)
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
            else
            {
                //Cargo datos en modo Admin (VistaUser)
                if (string.IsNullOrEmpty(articulo.ImagenUrl))
                    imgArticuloAdminUser.ImageUrl = "./Images/SinImagen.png";
                else
                    imgArticuloAdminUser.ImageUrl = articulo.ImagenUrl;

                lblNombreAdmin.Text = articulo.Nombre;
                lblMarcaAdmin.Text = articulo.Marca.Descripcion;
                lblCategoriaAdmin.Text = articulo.Categoria.Descripcion;
                lblPrecioAdmin.Text = "$" + articulo.Precio.ToString();
                lblDescripcionAdmin.Text = articulo.Descripcion;
            }
        }
    }
}