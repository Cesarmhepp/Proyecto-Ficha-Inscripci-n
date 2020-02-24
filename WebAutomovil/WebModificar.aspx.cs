using Biblioteca;
using Biblioteca.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomovil
{
    public partial class WebModificar : System.Web.UI.Page
    {
        int folio;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;" + "Initial Catalog=DB_M1;" + "Integrated Security=True");

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
                        //ddlCarrera.Text = dta.Rows[0][2].ToString();
                        txtNombreGrupo.Text = dta.Rows[0][3].ToString();
                        txtNroSemestre.Text = dta.Rows[0][4].ToString();
                        txtAñoSemestre.Text = dta.Rows[0][5].ToString();
                        // ddlTipoSemestre.SelectedValue = dta.Rows[0][6].ToString();
                        //  ddlsucursal.SelectedValue = dta.Rows[0][7].ToString();


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

                    if (Session["rut"].ToString()==txtRutProgra.Text || Session["rut"].ToString() == txtRutDBA.Text|| Session["rut"].ToString() == txtRutJefe.Text)
                    {
                        
                    }
                    else
                    {
                        Response.Redirect("MisProyectos.aspx");
                        Response.Write("<script language=javascript>alert('Debe ser parte del grupo para modificar esta ficha');</script>");
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
                }
                catch (Exception exc)
                {

                    Response.Write("<script language=javascript>alert('Error :" + exc.Message + "');</script>");
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
        


        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image ImagenOrinal,int alto)
        {
            var Radio = (double)alto / ImagenOrinal.Height;
            var NuevoAncho = (int)(ImagenOrinal.Width * Radio);
            var NuevoAlto = (int)(ImagenOrinal.Height * Radio);
            var NuevaImagenRedimencionada = new Bitmap(NuevoAlto, NuevoAlto);
            var g = Graphics.FromImage(NuevaImagenRedimencionada);
            return NuevaImagenRedimencionada;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                //toma de datos de semestre
                Semestre s = new Semestre();
                s.Numero = int.Parse(txtNroSemestre.Text);
                s.Año = int.Parse(txtAñoSemestre.Text);
                s.Fk_idTsem = int.Parse(ddlTipoSemestre.SelectedValue);
                //Toma de datos docentes
                Docente docPEP = new Docente();
                docPEP.RutDoc = ddlDocentePEP.SelectedValue;
                Docente docGPI = new Docente();
                docGPI.RutDoc = ddlDocenteGPI.SelectedValue;




                //toma de datos de grupo
                Grupo gp = new Grupo();
                gp.Nombre = txtNombreGrupo.Text;
                gp.Estado = 1;
                //toma de datos alumnoDBA
                Alumno aldba = new Alumno();
                Alumno alprogra = new Alumno();
                Alumno aljefe = new Alumno();

                aldba.RutAlumn = txtRutDBA.Text;
                aldba.Nombre = txtNombreDBA.Text;
                if (dueñoDba.Checked)
                {
                    aldba.DueñoIdea = 1;
                }
                aldba.Correo = "AA";
                aldba.Estado = 1;
                aldba.Fk_idCar = int.Parse(ddlCarrera.SelectedValue);
                aldba.Fk_idRol = 1;
                //para el valor fk_idsem se agrega desde la query
                //para el campof fk_idUs se agrega desde la query

                //INGRESO ALUMNO PROGRA

                alprogra.RutAlumn = txtRutProgra.Text;
                alprogra.Nombre = txtNomProgra.Text;
                if (dueñoProgra.Checked)
                {
                    alprogra.DueñoIdea = 1;
                }
                alprogra.Correo = "AA";
                alprogra.Estado = 1;
                alprogra.Fk_idCar = int.Parse(ddlCarrera.SelectedValue);
                alprogra.Fk_idRol = 3;
                //para el valor fk_idsem se agrega desde la query
                //para el campof fk_idUs se agrega desde la query

                //INGRESO ALUMNO JEFE

                aljefe.RutAlumn = txtRutJefe.Text;
                aljefe.Nombre = txtNombreJEfe.Text;
                if (dueñoJefe.Checked)
                {
                    aljefe.DueñoIdea = 1;
                }
                aljefe.Correo = "AA";
                aljefe.Estado = 1;
                aljefe.Fk_idCar = int.Parse(ddlCarrera.SelectedValue);
                aljefe.Fk_idRol = 2;
                //para el valor fk_idsem se agrega desde la query
                //para el campof fk_idUs se agrega desde la query


                //toma de datos tabla proyecto

                Proyecto p = new Proyecto();
                p.Nombre = txtNombre_Proyecto.Text;
                //Toma de tipo de desarrollo

                if (rdMovil.Checked)
                {
                    p.Fk_idDe = 1;
                }
                else if (rdWeb.Checked)
                {
                    p.Fk_idDe = 2;
                }
                else if (rdArduino.Checked)
                {
                    p.Fk_idDe = 3;
                }
                else if (rdclienteServidor.Checked)
                {
                    p.Fk_idDe = 4;
                }
                //Toma de tipo de negocio

                if (rdEmpren.Checked)
                {
                    p.Fk_idTneg = 1;
                }
                else if (rdVincula.Checked)
                {
                    p.Fk_idTneg = 2;
                }

                //toma de sucursal
                p.Fk_idSuc = int.Parse(ddlsucursal.SelectedValue);
                //toma de datos Descrpproyecto
                DescrpProyecto des = new DescrpProyecto();
                des.Link = txtLinkPitch.Text;
                des.Identificacion = txtIdentificacion.Text;
                des.Origen = txtOrigen.Text;
                des.Afectados = txtAfectados.Text;
                des.Justificacion = txtJustificacion.Text;
                des.Propuesta_solucion = txtPropuesta.Text;
                des.Definiciones = txtDefiniciones.Text;
                des.Estado = 0;

            //guardado de imagen

                if (fuDiagrama.HasFile)
                {
                    try
                    {
                        int tamanio = fuDiagrama.PostedFile.ContentLength;
                        byte[] ImagenOriginal = new byte[tamanio];
                        fuDiagrama.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                        Bitmap ImagenOriginalBinaria = new Bitmap(fuDiagrama.PostedFile.InputStream);
                        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
                        des.Diagrama_func = ImagenOriginal;
                    }
                    catch (Exception exe)
                    {

                        Response.Write("<script language=javascript>alert('Error al ingresar la imagen: " + exe.Message + "');</script>");

                    }
                }
                else
                {
                    des.Diagrama_func = new byte[0];
                }
           
                
               
                //toma de innovacion
                TipoInnovacion tp = new TipoInnovacion();

                if (rdBeacon.Checked)
                {
                    tp.IdTinno = 1;
                }
                else if (rdDron.Checked)
                {
                    tp.IdTinno = 2;
                }
                else if (rdRobotica.Checked)
                {
                    tp.IdTinno = 3;
                }
                else if (rdInternetDeLasCosas.Checked)
                {
                    tp.IdTinno = 4;
                }
                else if (rdLentesVr.Checked)
                {
                    tp.IdTinno = 5;
                }
                else if (rdOtro.Checked)
                {
                    tp.IdTinno = 6;
                    tp.Tipo = txtOtro.Text;
                }
                else if (rdDomotica.Checked)
                {
                    tp.IdTinno = 7;
                }
                //TOMA TIPO DE INOVACION NEGOCIO

                if (cbWebPay.Checked)
                {
                    p.Fk_idTin = 1;
                }
                else if (cbMigracion.Checked)
                {
                    p.Fk_idTin = 2;
                }
                else if (cbIntegraOtroSis.Checked)
                {
                    p.Fk_idTin = 3;
                }



                //Modificar datos



                if (Datos.ModificarFicha(s, gp, p, aldba, alprogra, aljefe, des, tp, docPEP, docGPI, folio))
                {
                    Response.Write("<script language=javascript>alert('Dato Modificado');</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Dato NO Ingresado');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('Error:" + ex.Message + "');</script>");

            }



        }
        

    }
}