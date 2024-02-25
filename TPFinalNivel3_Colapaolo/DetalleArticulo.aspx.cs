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
using System.IO;

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
                    Session["vistaAdmin"] = true;

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    List<Articulo> listaArticulos = negocioArt.listar();
                    articulo = listaArticulos.Find(x => x.Id == id);
                    Session.Add("articulo", articulo);
                    articulo = (Articulo)Session["articulo"];

                }
                else
                {
                    //Articulo Nuevo
                    articulo = null;
                    Session["articulo"] = null;
                    Session["vistaAdmin"] = true;
                }
            }

            if (Session["articulo"] != null)
            {


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
            else
            {
                //Nuevo Articulo


                if (!IsPostBack)
                {
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

                    ddlCategoria.SelectedValue = "1";
                    ddlMarca.SelectedValue = "1";
                }


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

        }

        protected void linkVistaAdmin_Click(object sender, EventArgs e)
        {
            articulo = (Articulo)Session["articulo"];

            if ((bool)Session["vistaAdmin"] == true)
                Session["vistaAdmin"] = false;
            else
                Session["vistaAdmin"] = true;

            if (Convert.ToBoolean(Session["vistaAdmin"]) == false)
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            articulo = new Articulo();

            try
            {
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Marca = new Marca();
                articulo.Marca.Id = Convert.ToInt32(ddlMarca.SelectedValue);
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = Convert.ToInt32(ddlCategoria.SelectedValue);
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);

                articulo.Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "-Sin Descripción-" : txtDescripcion.Text;


                //SELECCIONA LA UBICACION EN LA QUE ESTAMOS, SELECCIONA IMAGENART Y SE METE DENTRO
                string ruta = Server.MapPath("./ImagenArt/");
                string fecha = DateTime.Now.ToString("ddMMyyyyHHmmss");


                //SI NO ES NULO EL POSTEDFILE Y EL CONTENIDO ES MAYOR A 0 (TAMAÑO), EJECUTO EL CODIGO
                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {

                    //GUARDO LA IMAGEN QUE HE SELECCIONADO EN LA RUTA COMPLETA QUE QUEDARIA COMO "./ImagenArt/a-1.jpg"
                    txtImagen.PostedFile.SaveAs(ruta + "art-" + articulo.Codigo + fecha + ".jpg");
                    //GUARDO EL URL DE ESTA IMAGEN
                    articulo.ImagenUrl = "p-" + articulo.Codigo + fecha + ".jpg";

                }
                else
                {
                    articulo.ImagenUrl = "";
                }

                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.agregar(articulo);

                if (Request.UrlReferrer != null)
                {
                    // Redirijo a la página de referencia
                    string urlAnterior = Request.QueryString["returnUrl"];
                    Response.Redirect(urlAnterior, false);
                }
                else
                {
                    // Manejo caso donde no haya una URL de referencia
                    Response.Redirect("Index.aspx", false);
                }

            }
            catch (Exception)
            {
                articulo = null;
                throw;
            }
            
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModalEliminarArt_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocioArt = new ArticuloNegocio();
            articulo = (Articulo)Session["articulo"];
            int id = articulo.Id;

            negocioArt.eliminar(id);

            if (Request.UrlReferrer != null)
            {
                // Redirijo a la página de referencia
                string urlAnterior = Request.QueryString["returnUrl"];
                Response.Redirect(urlAnterior, false);
            }
            else
            {
                // Manejo caso donde no haya una URL de referencia
                Response.Redirect("Index.aspx", false);
            }
        }
    }
}