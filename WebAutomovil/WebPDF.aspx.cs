using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomovil
{
    public partial class WebPDF : System.Web.UI.Page
    {
        int folio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["parametro"] != null)
                {
                    folio = int.Parse(Request.Params["parametro"]);
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Debe ingresar algun numero de folio');</script>");
                    Response.Redirect("MisProyectos.aspx");
                }
                SqlConnection con = new SqlConnection("Data Source=localhost;" + "Initial Catalog=DB_M1;" + "Integrated Security=True");

                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from descrpproyecto where fk_folio=@folio", con);
                    cmd.Parameters.AddWithValue("folio", folio);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        txtLinkPitch.Text = dt.Rows[0][1].ToString();
                        txtIdentificacion.Text = dt.Rows[0][2].ToString();
                        txtOrigen.Text = dt.Rows[0][3].ToString();
                        txtAfectados.Text = dt.Rows[0][4].ToString();
                        txtJustificacion.Text = dt.Rows[0][5].ToString();
                        txtPropuesta.Text = dt.Rows[0][6].ToString();
                        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dt.Rows[0][7]);
                        imgDiagrama.ImageUrl = ImagenDataURL64;


                    }


                    SqlCommand cmdex = new SqlCommand("SELECT Proyecto.folio, Proyecto.nombre, Carrera.nombre AS Carrera, Grupo.nombre AS Expr2, Semestre.numero, Semestre.Año, TipoSemestre.tipo, Sucursal.sucursal FROM Grupo INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru INNER JOIN Semestre ON Proyecto.fk_idSem = Semestre.idSem INNER JOIN TipoSemestre ON Semestre.fk_idTSem = TipoSemestre.idTSem INNER JOIN Sucursal ON Proyecto.fk_idSuc = Sucursal.idSuc CROSS JOIN Carrera where folio=@folio;", con);
                    cmdex.Parameters.AddWithValue("folio", folio);
                    SqlDataAdapter sdas = new SqlDataAdapter(cmdex);
                    DataTable dta = new DataTable();
                    sdas.Fill(dta);

                    if (dta.Rows.Count == 1)
                    {
                        txtNombre_Proyecto.Text = dta.Rows[0][1].ToString();
                        txtCarrera.Text = dta.Rows[0][2].ToString();
                        txtNombreGrupo.Text = dta.Rows[0][3].ToString();
                        txtNroSemestre.Text = dta.Rows[0][4].ToString();
                        txtAñoSemestre.Text = dta.Rows[0][5].ToString();
                        txtTipoSemestre.Text = dta.Rows[0][6].ToString();
                        txtSucursal.Text = dta.Rows[0][7].ToString();


                    }

                    //relleno jefe proyecto
                    SqlCommand cmdi = new SqlCommand("SELECT Alumno.rutAlum, Alumno.nombre, Alumno.dueñoIdea FROM Alumno INNER JOIN alumno_grupo ON Alumno.rutAlum = alumno_grupo.fk_rutAlum INNER JOIN Grupo ON alumno_grupo.fk_idGru = Grupo.idGru INNER JOIN Rol ON Alumno.fk_idRol = Rol.idRol INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru where proyecto.folio=@folio and rol.rol='JEFE PROYECTO'", con);
                    cmdi.Parameters.AddWithValue("folio", folio);
                    SqlDataAdapter di = new SqlDataAdapter(cmdi);
                    DataTable dtai = new DataTable();
                    di.Fill(dtai);

                    if (dtai.Rows.Count == 1)
                    {
                        txtRutJefe.Text = dtai.Rows[0][0].ToString();
                        txtNombreJEfe.Text = dtai.Rows[0][1].ToString();
                        if (dtai.Rows[0][2].Equals(true))
                        {
                            dueñoJefe.Checked = true;
                        }
                    }

                    //relleno DBA
                    SqlCommand cmdii = new SqlCommand("SELECT Alumno.rutAlum, Alumno.nombre, Alumno.dueñoIdea FROM Alumno INNER JOIN alumno_grupo ON Alumno.rutAlum = alumno_grupo.fk_rutAlum INNER JOIN Grupo ON alumno_grupo.fk_idGru = Grupo.idGru INNER JOIN Rol ON Alumno.fk_idRol = Rol.idRol INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru where proyecto.folio=@folio and rol.rol='DBA'", con);
                    cmdii.Parameters.AddWithValue("folio", folio);
                    SqlDataAdapter dii = new SqlDataAdapter(cmdii);
                    DataTable dtaii = new DataTable();
                    dii.Fill(dtaii);

                    if (dtaii.Rows.Count == 1)
                    {
                        txtRutDBA.Text = dtaii.Rows[0][0].ToString();
                        txtNombreDBA.Text = dtaii.Rows[0][1].ToString();
                        if (dtaii.Rows[0][2].Equals(true))
                        {
                            dueñoDba.Checked = true;
                        }
                    }

                    //relleno PROGRAMADOR
                    SqlCommand cmdiii = new SqlCommand("SELECT Alumno.rutAlum, Alumno.nombre, Alumno.dueñoIdea FROM Alumno INNER JOIN alumno_grupo ON Alumno.rutAlum = alumno_grupo.fk_rutAlum INNER JOIN Grupo ON alumno_grupo.fk_idGru = Grupo.idGru INNER JOIN Rol ON Alumno.fk_idRol = Rol.idRol INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru where proyecto.folio=@folio and rol.rol='PROGRAMADOR'", con);
                    cmdiii.Parameters.AddWithValue("folio", folio);
                    SqlDataAdapter diii = new SqlDataAdapter(cmdiii);
                    DataTable dtaiii = new DataTable();
                    diii.Fill(dtaiii);

                    if (dtaiii.Rows.Count == 1)
                    {
                        txtRutProgra.Text = dtaiii.Rows[0][0].ToString();
                        txtNomProgra.Text = dtaiii.Rows[0][1].ToString();
                        if (dtaiii.Rows[0][2].Equals(true))
                        {
                            dueñoProgra.Checked = true;
                        }
                    }

                    //carga definicion
                    SqlCommand cmdiiii = new SqlCommand("SELECT Definiciones.definicion FROM Definiciones INNER JOIN DefProyecto ON Definiciones.idDef = DefProyecto.fk_idDef INNER JOIN Proyecto ON DefProyecto.fk_folio = Proyecto.folio WHERE(Proyecto.folio = " + folio + ")", con);
                    SqlDataAdapter diiii = new SqlDataAdapter(cmdiiii);
                    DataTable dtaiiii = new DataTable();
                    diiii.Fill(dtaiiii);
                    if (dtaiiii.Rows.Count == 1)
                    {
                        txtDefiniciones.Text = dtaiiii.Rows[0][0].ToString();
                    }

                    //carga de tipo de desarrollo
                    SqlCommand cmdTpDe = new SqlCommand("SELECT Desarrollo.tipo, Desarrollo.idDE FROM Proyecto INNER JOIN Desarrollo ON Proyecto.fk_idDE = Desarrollo.idDE WHERE (Proyecto.folio = " + folio + ")", con);
                    SqlDataAdapter DaTpDe = new SqlDataAdapter(cmdTpDe);
                    DataTable DtTpDe = new DataTable();
                    DaTpDe.Fill(DtTpDe);
                    if (DtTpDe.Rows.Count == 1)
                    {
                        string tipo = DtTpDe.Rows[0][0].ToString();

                        if (tipo.Equals("APP MOVIL"))
                        {
                            rdMovil.Checked = true;
                        }
                        else if (tipo.Equals("PLATAFORMA WEB"))
                        {
                            rdWeb.Checked = true;
                        }
                        else if (tipo.Equals("ARDUINO"))
                        {
                            rdArduino.Checked = true;
                        }
                        else if (tipo.Equals("CLIENTE-SERVIDOR"))
                        {
                            rdclienteServidor.Checked = true;
                        }
                    }

                    //carga tipo de negocio
                    SqlCommand cmdTn = new SqlCommand("SELECT TipoNegocio.tipo FROM Proyecto INNER JOIN TipoNegocio ON Proyecto.fk_idTNeg = TipoNegocio.idTNeg WHERE (Proyecto.folio = " + folio + ")", con);
                    SqlDataAdapter DaTn = new SqlDataAdapter(cmdTn);
                    DataTable DtTn = new DataTable();
                    DaTn.Fill(DtTn);

                    if (DtTn.Rows.Count == 1)
                    {
                        string tipo = DtTn.Rows[0][0].ToString();

                        if (tipo.Equals("EMPRENDIMIENTO"))
                        {
                            rdEmpren.Checked = true;
                        }
                        else if (tipo.Equals("VINCULACION CON EL MEDIO"))
                        {
                            rdVincula.Checked = true;
                        }
                    }

                    //carga Tipo de innovacion
                    SqlCommand cmdTi = new SqlCommand("SELECT TipoInnovacion.tipo FROM Proyecto INNER JOIN DetInnovacion ON Proyecto.folio = DetInnovacion.fk_folio INNER JOIN TipoInnovacion ON DetInnovacion.fk_idTInno = TipoInnovacion.idTInno where proyecto.folio=" + folio + ";", con);
                    SqlDataAdapter DaTi = new SqlDataAdapter(cmdTi);
                    DataTable DtTi = new DataTable();
                    DaTi.Fill(DtTi);

                    if (DtTi.Rows.Count == 1)
                    {
                        string tipoTi = DtTi.Rows[0][0].ToString();
                        if (tipoTi.Equals("BEACONS"))
                        {
                            rdBeacon.Checked = true;
                        }
                        else if (tipoTi.Equals("DRON"))
                        {
                            rdDron.Checked = true;
                        }
                        else if (tipoTi.Equals("ROBOTICA"))
                        {
                            rdRobotica.Checked = true;
                        }
                        else if (tipoTi.Equals("INTERNET DE LAS COSAS"))
                        {
                            rdInternetDeLasCosas.Checked = true;
                        }
                        else if (tipoTi.Equals("VR"))
                        {
                            rdLentesVr.Checked = true;
                        }
                        else if (tipoTi.Equals("OTRO"))
                        {
                            rdOtro.Checked = true;
                            SqlCommand cmdOtroTi = new SqlCommand("SELECT Tecnologias.nombre_tecnologia FROM Proyecto INNER JOIN DetInnovacion ON Proyecto.folio = DetInnovacion.fk_folio INNER JOIN TipoInnovacion ON DetInnovacion.fk_idTInno = TipoInnovacion.idTInno INNER JOIN Tecnologias ON TipoInnovacion.idTInno = Tecnologias.fk_idTInno where proyecto.folio=" + folio + ";", con);
                            SqlDataAdapter DaOtroTi = new SqlDataAdapter(cmdOtroTi);
                            DataTable DtOtroTi = new DataTable();
                            DaOtroTi.Fill(DtOtroTi);
                            if (DtOtroTi.Rows.Count == 1)
                            {
                                txtOtro.Text = DtOtroTi.Rows[0][0].ToString();
                            }
                        }
                        else if (tipoTi.Equals("DOMOTICA"))
                        {
                            rdDomotica.Checked = true;
                        }
                    }

                    //CARGA DE TIPO DE INNOVACION NEGOCIO
                    SqlCommand cmdTin = new SqlCommand("select fk_idTin from proyecto where folio=" + folio + "", con);
                    SqlDataAdapter DaTin = new SqlDataAdapter(cmdTin);
                    DataTable DtTin = new DataTable();
                    DaTin.Fill(DtTin);
                    if (DtTin.Rows.Count == 1)
                    {
                        if (DtTin.Rows[0][0].ToString().Equals("1"))
                        {
                            cbWebPay.Checked = true;
                        }
                        else if (DtTin.Rows[0][0].ToString().Equals("2"))
                        {
                            cbMigracion.Checked = true;
                        }
                        else if (DtTin.Rows[0][0].ToString().Equals("3"))
                        {
                            cbIntegraOtroSis.Checked = true;
                        }
                    }

                    //RELLENO DOCENTE PEP
                    SqlCommand cmdDocentePEP = new SqlCommand("SELECT Docente.nombre, Asignatura.nombre AS Expr1 FROM Proyecto INNER JOIN DocentesPro ON Proyecto.folio = DocentesPro.Proyecto_folio INNER JOIN Docente ON DocentesPro.Docente_rutDoc = Docente.rutDoc INNER JOIN asig_seccion ON Docente.rutDoc = asig_seccion.fk_rutDoc INNER JOIN Asignatura ON asig_seccion.fk_idAsig = Asignatura.idAsig WHERE (Proyecto.folio = " + folio + ") and Asignatura.idASig=1", con);
                    SqlDataAdapter SdaDocPEP = new SqlDataAdapter(cmdDocentePEP);
                    DataTable DtDocPep = new DataTable();
                    SdaDocPEP.Fill(DtDocPep);


                    txtDocentePEP.Text = DtDocPep.Rows[0][0].ToString();


                    //RELLENO DOCENTE GPI
                    SqlCommand cmdDocenteGPI = new SqlCommand("SELECT Docente.nombre, Asignatura.nombre AS Expr1 FROM Proyecto INNER JOIN DocentesPro ON Proyecto.folio = DocentesPro.Proyecto_folio INNER JOIN Docente ON DocentesPro.Docente_rutDoc = Docente.rutDoc INNER JOIN asig_seccion ON Docente.rutDoc = asig_seccion.fk_rutDoc INNER JOIN Asignatura ON asig_seccion.fk_idAsig = Asignatura.idAsig WHERE (Proyecto.folio = " + folio + ") and Asignatura.idASig=2", con);
                    SqlDataAdapter SdaDocGPI = new SqlDataAdapter(cmdDocenteGPI);
                    DataTable DtDocGPI = new DataTable();
                    SdaDocGPI.Fill(DtDocGPI);


                    txtDocenteGPI.Text = DtDocGPI.Rows[0][0].ToString();

                    //MOSTRAR IMAGEN
                    

                }
                catch (Exception ex)
                {

                    Response.Write("<script language=javascript>alert('Error :" + ex.Message + "');</script>");
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {

                if (Request.Params["parametro"] != null)
                {
                    folio = int.Parse(Request.Params["parametro"]);
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Debe ingresar algun numero de folio');</script>");
                    Response.Redirect("MisProyectos.aspx");
                }
            }




        }


        protected void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {

                var Renderer = new IronPdf.HtmlToPdf();
                var PDF = Renderer.RenderUrlAsPdf("http://localhost:60433/WebPDF.aspx?parametro=" + folio);
                PDF.SaveAs(@"C:\Users\Marco\Desktop\Ficha" + txtNombre_Proyecto.Text + ".pdf");
                // This neat trick opens our PDF file so we can see the result
                System.Diagnostics.Process.Start(@"C:\Users\Marco\Desktop\Ficha" + txtNombre_Proyecto.Text + ".pdf");

            }
            catch (Exception ex)
            {

                Response.Write("<script language=javascript>alert('Error: " + ex.Message + "');</script>");
            }


        }
    }
}