using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TPFinalNivel3_Colapaolo
{
    public partial class Informe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["informe"] = Request.QueryString["informe"] == null ? false : Convert.ToBoolean(Request.QueryString["informe"].ToString());

            //INFORME (Verde)
            if (Convert.ToBoolean(Session["informe"]) == true)
            {
                bodyBg.Attributes["class"] = "bg-success d-flex justify-content-center align-items-center vh-100";
                lblError.Text = "Exito!";
                lblError.CssClass = "text-center text-success fs-1 ms-5 fw-bold cursorDefault";
                lblInforme.CssClass = "d-flex justify-content-center fw-bold text-success h5 mt-4 mb-4 cursorDefault";
                lblEmoji.Text = "Bienvenido!";
                iEmoji.Attributes["class"] = "bi bi-emoji-laughing ms-2 text-success";

                if (Session["mensajeInforme"] != null)
                    lblInforme.Text = Session["mensajeInforme"].ToString();
                else
                    Response.Redirect("Index.aspx", false);
            }
            else
            {
                //Error (Rojo)
                if (Session["Error"] != null)
                    lblInforme.Text = Session["Error"].ToString();
                else
                    Response.Redirect("Index.aspx", false);
            }





        }
    }
}