using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomovil
{
    public partial class WebListarDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFolio.Text.Equals(""))
                {
                    Response.Write("<script language=javascript>alert('Debe ingresar algun numero de folio');</script>");

                }
                else
                {
                    Response.Write("<script type='text/javascript'>window.open('WebPDF.aspx?parametro=" + txtFolio.Text + "');</script>");

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script language=javascript>alert('Error:" + ex.Message + "');</script>");

            }
        }
    }

    
}