using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Biblioteca;

namespace WebAutomovil
{
    public partial class GrupoAdd : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnImportar_Click(object sender, EventArgs e)
        {
          //  try
          //  {
                string rollno;
                String sname;
                String fname;
                String mname;
                string path = Path.GetFileName(flExcel.FileName);
                path = path.Replace(" ", "");
                flExcel.SaveAs(Server.MapPath("~/ExcelFile/") + path);
                String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
                OleDbConnection mycon = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 12.0;HDR=YES;");
                mycon.Open();
                OleDbCommand cmd = new OleDbCommand("select * from [Hoja1$]", mycon);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Response.Write("<br/>"+dr[0].ToString());
                    rollno = dr[0].ToString();
                    sname = dr[1].ToString();
                    fname = dr[2].ToString();
                    mname = dr[3].ToString();
                    savedata(rollno);


                }
           // }
          //  catch (Exception ex)
          //  {

               // Response.Write("<script>alert('Error: "+ex.Message+"');</script>");
            //}
           



        }

        private void savedata(string rollno1)
        {
            String query = "insert into Usuario(idUs) values('"+rollno1+"')";
            SqlConnection con = new SqlConnection("Data Source=localhost;" + "Initial Catalog=DB_M1;" + "Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }


    }
}