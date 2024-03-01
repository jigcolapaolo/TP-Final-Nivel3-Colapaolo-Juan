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
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserNegocio negocioUser = new UserNegocio();

            }

            if (Session["user"] != null)
                Response.Redirect("Index.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserNegocio negocioUser = new UserNegocio();
            User user = new User();


            try
            {
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                if (negocioUser.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("Index.aspx", false);
                }
                else
                {
                    divErrorLogin.Attributes["class"] = "text-danger mt-1";
                    return;
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }
    }
}