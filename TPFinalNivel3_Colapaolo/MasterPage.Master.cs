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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public List<Marca> listaMarcas { get; set; }
        public List<Categoria> listaCategoria { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(listaMarcas == null)
                {
                    MarcaNegocio negocioMar = new MarcaNegocio();
                    CategoriaNegocio negocioCat = new CategoriaNegocio();
                    listaMarcas = negocioMar.listar();
                    listaCategoria = negocioCat.listar();
                }

                repeaterMarcas.DataSource = listaMarcas;
                repeaterMarcas.DataBind();
                repeaterCategoria.DataSource = listaCategoria;
                repeaterCategoria.DataBind();
            }
        }

    }
}