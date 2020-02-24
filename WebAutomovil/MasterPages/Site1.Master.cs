using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomovil
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["TipoUsuario"].ToString() != "alumno")
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblNombreUsu.Text = Session["usuario"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('Debe Logearsea  una cuenta');</script>");
                Response.Redirect("login.aspx");

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Session.Remove("TipoUsuario");
            Response.Redirect("login.aspx");
        }
    }
}