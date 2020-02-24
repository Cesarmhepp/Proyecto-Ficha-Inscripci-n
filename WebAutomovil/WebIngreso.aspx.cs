using Biblioteca;
using Biblioteca.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomovil
{
    public partial class WebIngreso : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Datos datos = new Datos();
                //toma de datos de semestre
                Semestre s = new Semestre();
                s.Numero = int.Parse(txtNroSemestre.Text);
                s.Año = int.Parse(txtAñoSemestre.Text);
                s.Fk_idTsem = int.Parse(ddlTipoSemestre.SelectedValue);
                //Toma de datos docentes
                Docente docPEP= new Docente();
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
            
                aldba.Correo = "AA";
                aldba.Estado = 1;
                aldba.Fk_idCar = int.Parse(ddlCarrera.SelectedValue);
                aldba.Fk_idRol = 1;
                //para el valor fk_idsem se agrega desde la query
                //para el campof fk_idUs se agrega desde la query

                //INGRESO ALUMNO PROGRA

                alprogra.RutAlumn = txtRutProgra.Text;
                alprogra.Nombre = txtNomProgra.Text;
            
                alprogra.Correo = "AA";
                alprogra.Estado = 1;
                alprogra.Fk_idCar = int.Parse(ddlCarrera.SelectedValue);
                alprogra.Fk_idRol = 3;
                //para el valor fk_idsem se agrega desde la query
                //para el campof fk_idUs se agrega desde la query

                //INGRESO ALUMNO JEFE

                aljefe.RutAlumn = txtRutJefe.Text;
                aljefe.Nombre = txtNombreJEfe.Text;
           
                aljefe.Correo = "AA";
                aljefe.Estado = 1;
                aljefe.Fk_idCar = int.Parse(ddlCarrera.SelectedValue);
                aljefe.Fk_idRol = 2;
                //para el valor fk_idsem se agrega desde la query
                //para el campof fk_idUs se agrega desde la query

                //definir dueño de la idea
                if (dueñoDba.Checked)
                {
                    aldba.DueñoIdea = 1;
                }
                else if (dueñoProgra.Checked)
                {
                    alprogra.DueñoIdea = 1;
                }
                else if (dueñoJefe.Checked)
                {
                    aljefe.DueñoIdea = 1;
                }else
                {
                    throw new Exception("Debe seleccionar algun dueño de la idea");
                }

                //DEFINICION JEFE DE PROYECTO


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
                } else if (rdVincula.Checked)
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

                if (fuDiagrama.HasFile)
                {
                    //guardado de imagen         
                    int tamanio = fuDiagrama.PostedFile.ContentLength;
                    byte[] ImagenOriginal = new byte[tamanio];
                    fuDiagrama.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                    Bitmap ImagenOriginalBinaria = new Bitmap(fuDiagrama.PostedFile.InputStream);
                    string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
                    imgDiagrama.ImageUrl = ImagenDataURL64;
                    des.Diagrama_func = ImagenOriginal;
                }
                else
                {
                    throw new Exception("Debe ingresar alguna imagen");
                }
                    
                des.Estado = 0;
                //toma de descripcion proyecto
                
                
                
                //toma de innovacion
                TipoInnovacion tp = new TipoInnovacion();
    

                if (rdBeacon.Checked)
                {
                    tp.IdTinno = 1;
                } else if(rdDron.Checked)
                {
                    tp.IdTinno = 2;
                } else if(rdRobotica.Checked)
                {
                    tp.IdTinno = 3;
                } else if(rdInternetDeLasCosas.Checked)
                {
                    tp.IdTinno = 4;
                } else if(rdLentesVr.Checked)
                {
                    tp.IdTinno = 5;                
                }else if (rdOtro.Checked)
                {
                    tp.IdTinno = 6;
                    tp.Tipo = txtOtro.Text;
                }
                else if (rdDomotica.Checked)
                {
                    tp.IdTinno = 7;
                }
                //TOMA TIPO DE INOVACION NEGOCIO
                TipoInnovacionNegocio tin = new TipoInnovacionNegocio();
                if (cbWebPay.Checked)
                {
                    tin.IdTin = 1;
                }
                else if (cbMigracion.Checked)
                {
                    tin.IdTin = 2;
                }
                else if (cbIntegraOtroSis.Checked)
                {
                    tin.IdTin = 3;
                }



                //inserto de datos

                if (datos.InsertarFicha(s, gp, p,aldba,alprogra,aljefe,des,tp,docPEP,docGPI,tin))
                {
                    Response.Write("<script language=javascript>alert('Dato Ingresado');</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Dato NO Ingresado');</script>");
                }
                                        
            }
            catch(Exception ex)
            {
                Response.Write("<script language=javascript>alert('Error: "+ ex.Message + "');</script>");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting1(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void rdDesarrollo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void rdTipoNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void txtOtro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}