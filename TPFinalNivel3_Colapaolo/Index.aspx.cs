﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Helper;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Threading.Tasks;

namespace TPFinalNivel3_Colapaolo
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ListaArticulos == null)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    ListaArticulos = negocio.listar();
                }

                repRepeater.DataSource = ListaArticulos;
                repRepeater.DataBind();
            }

        }


    }
}