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
            User user = Session["user"] != null ? (User)Session["user"] : null;

            if (user == null)
            {
                Response.Redirect("Index.aspx");
            }


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
                    //Si no recibe un id de un articulo y es admin, es porque estoy queriendo agregar un nuevo articulo, si no, no
                    //permito el ingreso.
                    if (Seguridad.isAdmin(Session["user"]))
                    {
                        //Articulo Nuevo
                        articulo = null;
                        Session["articulo"] = null;
                        Session["vistaAdmin"] = true;

                    }
                    else
                    {
                        Response.Redirect("Index.aspx");
                    }


                }

                if (articulo != null)
                {
                    //Icono favorito
                    List<Articulo> listaFavoritos = (List<Articulo>)Session["listaFavoritos"];

                    if (listaFavoritos.Any(art => art.Id == articulo.Id))
                    {
                        if (Seguridad.isAdmin(Session["user"]))
                        {
                            lblStarAdmin.CssClass = "form-check-label bi bi-star-fill";
                            chkFavoritoAdmin.Checked = true;

                        }
                        else
                        {
                            lblStarUser.CssClass = "form-check-label bi bi-star-fill";
                            chkFavoritoUser.Checked = true;

                        }
                    }
                    else
                    {
                        if (Seguridad.isAdmin(Session["user"]))
                        {
                            lblStarAdmin.CssClass = "form-check-label bi bi-star";
                            chkFavoritoAdmin.Checked = false;

                        }
                        else
                        {
                            lblStarUser.CssClass = "form-check-label bi bi-star";
                            chkFavoritoUser.Checked = false;

                        }
                    }
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
                        imgArticulo.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;



                    lblNombre.Text = articulo.Nombre;
                    lblMarca.Text = articulo.Marca.Descripcion;
                    lblCategoria.Text = articulo.Categoria.Descripcion;
                    lblPrecio.Text = "$" + articulo.Precio.ToString("0.00", CultureInfo.InvariantCulture);
                    lblDescripcion.Text = articulo.Descripcion;

                }
                else
                {
                    //Si cambie a vista User y vuelvo a Admin, cargo los datos
                    if ((bool)Session["vistaAdmin"] == false)
                    {
                        articulo = (Articulo)Session["articulo"];

                        //Cargo datos en modo Admin (VistaAdmin)
                        if (string.IsNullOrEmpty(articulo.ImagenUrl))
                            imgArticuloAdmin.ImageUrl = "./Images/SinImagen.png";
                        else
                            imgArticuloAdmin.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;

                        txtCodigo.Text = articulo.Codigo;
                        txtNombre.Text = articulo.Nombre;
                        txtPrecio.Text = articulo.Precio.ToString("0.00", CultureInfo.InvariantCulture);
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
                            imgArticuloAdminUser.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;

                        lblNombreAdmin.Text = articulo.Nombre;
                        lblMarcaAdmin.Text = articulo.Marca.Descripcion;
                        lblCategoriaAdmin.Text = articulo.Categoria.Descripcion;
                        lblPrecioAdmin.Text = "$" + articulo.Precio.ToString();
                        lblDescripcionAdmin.Text = articulo.Descripcion;

                    }

                    if ((bool)Session["vistaAdmin"] == true)
                    {
                        articulo = (Articulo)Session["articulo"];

                        //Cargo datos en modo Admin (VistaAdmin)
                        if (string.IsNullOrEmpty(articulo.ImagenUrl))
                            imgArticuloAdmin.ImageUrl = "./Images/SinImagen.png";
                        else
                            imgArticuloAdmin.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;

                        txtCodigo.Text = articulo.Codigo;
                        txtNombre.Text = articulo.Nombre;
                        txtPrecio.Text = articulo.Precio.ToString("0.00", CultureInfo.InvariantCulture);
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
                            imgArticuloAdminUser.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;

                        lblNombreAdmin.Text = articulo.Nombre;
                        lblMarcaAdmin.Text = articulo.Marca.Descripcion;
                        lblCategoriaAdmin.Text = articulo.Categoria.Descripcion;
                        lblPrecioAdmin.Text = "$" + articulo.Precio.ToString();
                        lblDescripcionAdmin.Text = articulo.Descripcion;


                    }


                    if (!IsPostBack)
                    {
                        articulo = (Articulo)Session["articulo"];

                        //Cargo datos en modo Admin (VistaAdmin)
                        if (string.IsNullOrEmpty(articulo.ImagenUrl))
                            imgArticuloAdmin.ImageUrl = "./Images/SinImagen.png";
                        else
                            imgArticuloAdmin.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;

                        txtCodigo.Text = articulo.Codigo;
                        txtNombre.Text = articulo.Nombre;
                        txtPrecio.Text = articulo.Precio.ToString("0.00", CultureInfo.InvariantCulture);
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
                            imgArticuloAdminUser.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;

                        lblNombreAdmin.Text = articulo.Nombre;
                        lblMarcaAdmin.Text = articulo.Marca.Descripcion;
                        lblCategoriaAdmin.Text = articulo.Categoria.Descripcion;
                        lblPrecioAdmin.Text = "$" + articulo.Precio.ToString();
                        lblDescripcionAdmin.Text = articulo.Descripcion;

                    }

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
                    imgArticuloAdmin.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;

                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtPrecio.Text = articulo.Precio.ToString("0.00", CultureInfo.InvariantCulture);
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
                    imgArticuloAdminUser.ImageUrl = articulo.ImagenUrl.StartsWith("art") ? "~/ImagenArt/" + articulo.ImagenUrl : articulo.ImagenUrl;

                lblNombreAdmin.Text = articulo.Nombre;
                lblMarcaAdmin.Text = articulo.Marca.Descripcion;
                lblCategoriaAdmin.Text = articulo.Categoria.Descripcion;
                lblPrecioAdmin.Text = "$" + articulo.Precio.ToString("0.000");
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
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                articulo.Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? "-Sin Descripción-" : txtDescripcion.Text;


                //SELECCIONA LA UBICACION EN LA QUE ESTAMOS, SELECCIONA IMAGENART Y SE METE DENTRO
                string ruta = Server.MapPath("./ImagenArt/");
                string fecha = DateTime.Now.ToString("ddMMyyyyHHmmss");

                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {
                    //GUARDO LA IMAGEN QUE HE SELECCIONADO EN LA RUTA COMPLETA QUE QUEDARIA COMO "./ImagenArt/art-1.jpg"
                    txtImagen.PostedFile.SaveAs(ruta + "art-" + articulo.Codigo + fecha + ".jpg");
                    //GUARDO EL URL DE ESTA IMAGEN
                    articulo.ImagenUrl = "art-" + articulo.Codigo + fecha + ".jpg";

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
            articulo = (Articulo)Session["articulo"];

            try
            {
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Precio = decimal.TryParse(txtPrecio.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal precio) ? precio : 0;
                articulo.Descripcion = txtDescripcion.Text;

                string ruta = Server.MapPath("./ImagenArt/");
                string patronBusqueda = "art-" + articulo.Codigo + "*.jpg";
                string fecha = DateTime.Now.ToString("ddMMyyyyHHmmss");
                string[] archivosEncontrados = Directory.GetFiles(ruta, patronBusqueda);

                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {
                    //Elimina todas las imagenes anteriores que pudo tener este articulo y luego guarda la nueva.
                    foreach (string archivo in archivosEncontrados)
                    {
                        File.Delete(archivo);
                    }

                    txtImagen.PostedFile.SaveAs(ruta + "art-" + articulo.Codigo + fecha + ".jpg");
                    //GUARDO EL URL DE ESTA IMAGEN
                    articulo.ImagenUrl = "art-" + articulo.Codigo + fecha + ".jpg";
                }

                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.modificar(articulo);


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

                throw;
            }

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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
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

        protected void chkFavoritoUser_CheckedChanged(object sender, EventArgs e)
        {
            articulo = (Articulo)Session["articulo"];
            List<Articulo> listaFavoritos = (List<Articulo>)Session["listaFavoritos"];
            User user = (User)Session["user"];
            ArticuloNegocio negocio = new ArticuloNegocio();

            CheckBox chkFavorito = (CheckBox)sender;


            if (chkFavorito.Checked)
            {

                if (!listaFavoritos.Any(art => art.Id == articulo.Id))
                {
                    negocio.agregarFavorito(user.Id, articulo.Id);
                    Session["listaFavoritos"] = negocio.listarFavoritos(user.Id);
                }

                lblStarUser.CssClass = "form-check-label bi bi-star-fill";
            }
            else
            {
                negocio.eliminarFavorito(user.Id, articulo.Id);
                Session["listaFavoritos"] = negocio.listarFavoritos(user.Id);

                lblStarUser.CssClass = "form-check-label bi bi-star";

            }
        }

        protected void chkFavoritoAdmin_CheckedChanged(object sender, EventArgs e)
        {
            articulo = (Articulo)Session["articulo"];
            List<Articulo> listaFavoritos = (List<Articulo>)Session["listaFavoritos"];
            User user = (User)Session["user"];
            ArticuloNegocio negocio = new ArticuloNegocio();

            CheckBox chkFavorito = (CheckBox)sender;


            if (chkFavorito.Checked)
            {

                if (!listaFavoritos.Any(art => art.Id == articulo.Id))
                {
                    negocio.agregarFavorito(user.Id, articulo.Id);
                    Session["listaFavoritos"] = negocio.listarFavoritos(user.Id);
                }

                lblStarAdmin.CssClass = "form-check-label bi bi-star-fill";
            }
            else
            {
                if ((bool)Session["vistaAdmin"] != true)
                {
                    negocio.eliminarFavorito(user.Id, articulo.Id);
                    Session["listaFavoritos"] = negocio.listarFavoritos(user.Id);

                    lblStarAdmin.CssClass = "form-check-label bi bi-star";

                }
                else
                {
                    if (listaFavoritos.Any(art => art.Id == articulo.Id))
                    {
                        chkFavoritoAdmin.Checked = true;
                    }
                }

            }
        }
    }
}