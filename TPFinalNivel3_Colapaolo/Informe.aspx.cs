using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Colapaolo
{
    public partial class Informe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Error"] != null)
                lblInforme.Text = Session["Error"].ToString();
            else
                Response.Redirect("Index.aspx", false);
        }
    }
}