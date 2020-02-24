using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomovil
{
    public partial class MisFichas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txtFolioEdit.Text.Equals(""))
                {
                    Response.Write("<script language=javascript>alert('Debe ingresar algun numero de folio');</script>");

                }
                else
                {
                    Response.Redirect("WebModificar.aspx?parametro=" + txtFolioEdit.Text);
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script language=javascript>alert('Error:"+ex.Message+"');</script>");
                
            }
           
        }
    }
}