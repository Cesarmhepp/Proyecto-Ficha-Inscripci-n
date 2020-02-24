using Biblioteca;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomovil
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;" + "Initial Catalog=DB_M1;" + "Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select idUs,usuario,TipoUsuario from Usuario where idUs=@usuario and contraseña=@pass",con);
                cmd.Parameters.AddWithValue("usuario",txtUsu.Text);
                cmd.Parameters.AddWithValue("pass",txtContra.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][2].ToString() == "docente")
                    {
                        Session["rut"] = dt.Rows[0][0].ToString();
                        Session["usuario"] = dt.Rows[0][1].ToString();
                        Session["TipoUsuario"] = dt.Rows[0][2].ToString();
                        Response.Redirect("MenuDocente.aspx");
                    }
                    else if (dt.Rows[0][2].ToString() == "alumno")
                    {
                        Session["rut"] = dt.Rows[0][0].ToString();
                        Session["usuario"] = dt.Rows[0][1].ToString();
                        Session["TipoUsuario"] = dt.Rows[0][2].ToString();
                        Response.Redirect("WebPortada.aspx");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Error, Usuario o contraseña no validos');</script>");
                }

                
            }
            catch (Exception ex)
            {

                Response.Write("<script language=javascript>alert('Error: "+ex.Message+"');</script>");
                
            }
            finally
            {
                con.Close();
            }

            
        }


    }
}