using Biblioteca.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Datos
    {
        private Conexion c;

        public Datos()
        {
            c = new Conexion();
        }

        private void ejecutar(string sql)
        {

            c.con.Open();
            c.sen = new SqlCommand(sql, c.con);
            c.sen.ExecuteNonQuery();
            c.con.Close();
        }

        public bool InsertarFicha(Semestre sem, Grupo grupo,Proyecto p,Alumno Aldba,Alumno AlPro, Alumno alJefe,DescrpProyecto des,TipoInnovacion ti,Docente docPEP,Docente docGPI,TipoInnovacionNegocio tin)
        {
            bool estado = false;

            if (p.Nombre.Length > 0)
            {
                
                    //ingreso a tabla semestre

                    string insert1 = "insert into Semestre(numero,año,fk_idTSem) values(" + sem.Numero + "," + sem.Año + "," + sem.Fk_idTsem + ");";
                    ejecutar(insert1);
                    //ingreso a tabla grupo
                    string insert2 = "insert into grupo(nombre,estado) values('" + grupo.Nombre + "'," + 1 + ");";
                    ejecutar(insert2);
                    //ingreso a tabla proyecto
                    string insert3 = "insert into Proyecto(nombre,fk_idDe,fk_idTneg,fk_idSuc,fk_idSem,fk_idGru,fk_idTin)" +
                                      " values('" + p.Nombre + "'," + p.Fk_idDe + "," + p.Fk_idTneg + "," + p.Fk_idSuc + ",(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + "),(select idGru from grupo where nombre='" + grupo.Nombre + "'),"+tin.IdTin+");";
                    ejecutar(insert3);
                       
                    //ingresu a alumnos
                        //INGRESO DBA
                    string insertDBA = "insert into alumno values('" + Aldba.RutAlumn + "','" + Aldba.Nombre + "'," + Aldba.DueñoIdea + ",'" + Aldba.Correo + "'," + Aldba.Estado + "," + Aldba.Fk_idCar + "," + Aldba.Fk_idRol + ",(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + "),'" + Aldba.RutAlumn + "');";
                    ejecutar(insertDBA);
                        //INGRESO PROGRAMADOR
                    string insertpro = "insert into alumno values('" + AlPro.RutAlumn + "','" + AlPro.Nombre + "'," + AlPro.DueñoIdea + ",'" + AlPro.Correo + "'," + AlPro.Estado + "," + AlPro.Fk_idCar + "," + AlPro.Fk_idRol + ",(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + "),'" + AlPro.RutAlumn + "');";
                    ejecutar(insertpro);
                         //INGRESO JEFE
                    string insertJefe = "insert into alumno values('" + alJefe.RutAlumn + "','" + alJefe.Nombre + "'," + alJefe.DueñoIdea + ",'" + alJefe.Correo + "'," + alJefe.Estado + "," + alJefe.Fk_idCar + "," + alJefe.Fk_idRol + ",(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + "),'" + alJefe.RutAlumn + "');";
                    ejecutar(insertJefe);

                    //INGRESO TABLA ALUMNO-GRUPO
                    string insertAlumnoGrupoDBA = "insert into alumno_grupo values('"+Aldba.RutAlumn+ "',(select idGru from grupo where nombre='" + grupo.Nombre + "'));";
                    ejecutar(insertAlumnoGrupoDBA);
                    string insertAlumnoGrupoPROGRA = "insert into alumno_grupo values('" + AlPro.RutAlumn + "',(select idGru from grupo where nombre='" + grupo.Nombre + "'));";
                    ejecutar(insertAlumnoGrupoPROGRA);
                    string insertAlumnoGrupoJEFE = "insert into alumno_grupo values('" + alJefe.RutAlumn + "',(select idGru from grupo where nombre='" + grupo.Nombre + "'));";
                    ejecutar(insertAlumnoGrupoJEFE);

                    //INGRESO DESCRIPCION PROYECTO
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "insert into descrpProyecto(link,identificacion,origen,afectados,justificacion,propuesta_solucion,diagrama_func_,estado,fk_folio) values('"+des.Link+"','"+des.Identificacion+"','"+des.Origen+"','"+des.Afectados+"','"+des.Justificacion+"','"+des.Propuesta_solucion+"',@diagrama,1,(select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "')));";
                    cmd.Parameters.Add("@diagrama", SqlDbType.Image).Value = des.Diagrama_func;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = c.con;
                    c.con.Open();
                    cmd.ExecuteNonQuery();
                    c.con.Close();

                    //INGRESO TIPO INNOVACION
                    if (ti.IdTinno>=1 && ti.IdTinno<=7)
                    {
                        if (ti.IdTinno == 6)
                        {
                            string inserNuevoTipoInnovacion = "insert into Tecnologias (nombre_tecnologia,fk_idTinno) values('" + ti.Tipo + "'," + ti.IdTinno + ");";
                            ejecutar(inserNuevoTipoInnovacion);

                            string insertTp = "insert into detInnovacion (fk_folio,fk_idTinno) values((select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "')),(SELECT TipoInnovacion.idTInno FROM Tecnologias INNER JOIN TipoInnovacion ON Tecnologias.fk_idTInno = TipoInnovacion.idTInno where Tecnologias.nombre_tecnologia='"+ti.Tipo+"'));";
                            ejecutar(insertTp);
                        }
                        else
                        {
                            string insertTp = "insert into detInnovacion (fk_folio,fk_idTinno) values((select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "'))," + ti.IdTinno + ");";
                            ejecutar(insertTp);
                        }
                    }

                    
                    

                    //ingreso Definiciones
                    string insertdefproc = "insert into Definiciones(definicion) values('"+des.Definiciones+"')";
                    ejecutar(insertdefproc);

                        //ingreso a DefProyecto
                        string insertDefProyecto = "insert into defproyecto(fk_folio,fk_idDef) values((select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "')),(select idDef from definiciones where definicion='"+des.Definiciones+"'));";
                        ejecutar(insertDefProyecto);
                    //INGRESO DOCENTES
                        //INGRESO PEP
                        string insertPEP = "insert into DocentesPro(Docente_rutDoc,Proyecto_folio) values('" + docPEP.RutDoc + "',(select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "')))";
                        ejecutar(insertPEP);
                        //INGRESO GPI
                        string insertGPI = "insert into DocentesPro(Docente_rutDoc,Proyecto_folio) values('" + docGPI.RutDoc + "',(select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "')))";
                        ejecutar(insertGPI);
                    estado = true;
              
               
            }
            return estado;

        }

        public static bool ModificarFicha(Semestre sem, Grupo grupo, Proyecto p, Alumno Aldba, Alumno AlPro, Alumno alJefe, DescrpProyecto des, TipoInnovacion ti,Docente docPEP,Docente docGPI,int folio)
        {
            bool estado = false;
            if (p.Nombre.Length > 0)
            {

                
                    //Modificacion semestre
                    SqlConnection con = new SqlConnection("Data Source=localhost;" + "Initial Catalog=DB_M1;" + "Integrated Security=True");
                    con.Open();
                    SqlCommand cmdSem = new SqlCommand("UPDATE Semestre SET numero ="+sem.Numero+", Año ="+sem.Año+", fk_idTSem ="+sem.Fk_idTsem+" FROM Semestre INNER JOIN Proyecto ON Semestre.idSem = Proyecto.fk_idSem WHERE Proyecto.folio="+folio+";",con);
                    cmdSem.ExecuteNonQuery();

                    //modificarcion docentes
                        //PEP
                        SqlCommand updateDocPEP = new SqlCommand("UPDATE DocentesPro SET Docente_rutDoc ='" + docPEP.RutDoc + "' FROM Asignatura INNER JOIN asig_seccion ON Asignatura.idAsig = asig_seccion.fk_idAsig INNER JOIN Docente ON asig_seccion.fk_rutDoc = Docente.rutDoc INNER JOIN DocentesPro INNER JOIN Proyecto ON DocentesPro.Proyecto_folio = Proyecto.folio ON Docente.rutDoc = DocentesPro.Docente_rutDoc where proyecto.folio=" + folio + " and Asignatura.nombre='PREPARACION Y EVALUACION DE PROYECTOS DE TI';", con);
                        updateDocPEP.ExecuteNonQuery();
                        //GPI
                        SqlCommand updateDocGPI = new SqlCommand("UPDATE DocentesPro SET Docente_rutDoc ='" + docGPI.RutDoc + "' FROM Asignatura INNER JOIN asig_seccion ON Asignatura.idAsig = asig_seccion.fk_idAsig INNER JOIN Docente ON asig_seccion.fk_rutDoc = Docente.rutDoc INNER JOIN DocentesPro INNER JOIN Proyecto ON DocentesPro.Proyecto_folio = Proyecto.folio ON Docente.rutDoc = DocentesPro.Docente_rutDoc where proyecto.folio=" + folio + " and Asignatura.nombre='GESTION DE PROYECTOS INFORMATICOS';", con);
                        updateDocGPI.ExecuteNonQuery();
                    //Modificacion Grupo
                    SqlCommand cmdGrupoUpdate = new SqlCommand("UPDATE Grupo SET nombre ='"+grupo.Nombre+"' FROM Grupo INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru WHERE Proyecto.folio="+folio+";",con);
                    cmdGrupoUpdate.ExecuteNonQuery();

                    //ingreso a tabla proyecto
                    //Actualizar Tipo de innovacion
                    if (ti.IdTinno>=1 && ti.IdTinno<=7)
                    {
                        if (ti.IdTinno==6)
                        {                           
                            //Con esta query vamos a ver si ya existe algun Tipo de Innovacion de tipo otro agregado
                                SqlCommand selectDetInnoOtro = new SqlCommand("SELECT Tecnologias.nombre_tecnologia FROM Tecnologias INNER JOIN TipoInnovacion ON Tecnologias.fk_idTInno = TipoInnovacion.idTInno INNER JOIN DetInnovacion ON TipoInnovacion.idTInno = DetInnovacion.fk_idTInno INNER JOIN Proyecto ON DetInnovacion.fk_folio = Proyecto.folio WHERE Proyecto.folio="+folio+";",con);
                                SqlDataAdapter DaTi = new SqlDataAdapter(selectDetInnoOtro);
                                DataTable DtTi = new DataTable();
                                DaTi.Fill(DtTi);
                            //Con esta validacion vamos a ver si ya existe algun Tipo de Innovacion de tipo otro agregado

                            if (DtTi.Rows.Count==1)
                            {
                                //SI SOLO hay un resultado, ejecutara la query
                                 SqlCommand updateTipoOtro = new SqlCommand("UPDATE Tecnologias SET nombre_tecnologia ='" + ti.Tipo + "' FROM Tecnologias INNER JOIN TipoInnovacion ON Tecnologias.fk_idTInno = TipoInnovacion.idTInno INNER JOIN DetInnovacion ON TipoInnovacion.idTInno = DetInnovacion.fk_idTInno INNER JOIN Proyecto ON DetInnovacion.fk_folio = Proyecto.folio where Proyecto.folio=" + folio + ";", con);
                                 updateTipoOtro.ExecuteNonQuery();
                                                                                              
                            }
                            else if(DtTi.Rows.Count == 0)
                            {
                                //SI NO EXISTE UN REGISTRO DE TIPO OTRO, AGREGARMOS UN NUEVO DE TIPO OTRO y modificamos la tabla DetInnovacion
                                SqlCommand updateTinnoN = new SqlCommand("UPDATE DetInnovacion SET fk_idTInno =" + ti.IdTinno + " FROM DetInnovacion INNER JOIN Proyecto ON DetInnovacion.fk_folio = Proyecto.folio INNER JOIN TipoInnovacion ON DetInnovacion.fk_idTInno = TipoInnovacion.idTInno where Proyecto.folio=" + folio + ";", con);
                                updateTinnoN.ExecuteNonQuery();
                                SqlCommand insertOtro = new SqlCommand("insert into Tecnologias(nombre_tecnologia,fk_idTinno) values('" + ti.Tipo + "',6)", con);
                                insertOtro.ExecuteNonQuery();

                            }


                        }
                        else
                        {
                            //si la ficha tenia un tipo de innovacion de tipo otro, eliminara ese tipo otro, en caso que no, no lo hara.
                            SqlCommand cmdDeleteOtros = new SqlCommand("DELETE FROM Tecnologias FROM Tecnologias INNER JOIN TipoInnovacion ON Tecnologias.fk_idTInno = TipoInnovacion.idTInno INNER JOIN DetInnovacion ON TipoInnovacion.idTInno = DetInnovacion.fk_idTInno INNER JOIN Proyecto ON DetInnovacion.fk_folio = Proyecto.folio WHERE Proyecto.folio = " + folio + ";", con);
                            cmdDeleteOtros.ExecuteNonQuery();
                            SqlCommand updateTinno = new SqlCommand("UPDATE DetInnovacion SET fk_idTInno =" + ti.IdTinno + " FROM DetInnovacion INNER JOIN Proyecto ON DetInnovacion.fk_folio = Proyecto.folio INNER JOIN TipoInnovacion ON DetInnovacion.fk_idTInno = TipoInnovacion.idTInno where Proyecto.folio=" + folio + ";", con);
                            updateTinno.ExecuteNonQuery();
                        }
                       

                    }
                       
                    SqlCommand cmdProyectoUpdate = new SqlCommand("UPDATE Proyecto SET nombre='"+p.Nombre+"',fk_idDE ="+p.Fk_idDe+", fk_idTNeg ="+p.Fk_idTneg+", fk_idSuc ="+p.Fk_idSuc+", fk_idTin ="+p.Fk_idTin+" FROM Proyecto INNER JOIN Semestre ON Proyecto.fk_idSem = Semestre.idSem INNER JOIN Grupo ON Proyecto.fk_idGru = Grupo.idGru WHERE Proyecto.folio="+folio+"", con);
                    cmdProyectoUpdate.ExecuteNonQuery();
                        //modificacion a alumnos
                        //DBA
                        SqlCommand updateDBANombre = new SqlCommand("UPDATE Alumno SET nombre ='"+Aldba.Nombre+"',fk_idRol=1 FROM Alumno INNER JOIN alumno_grupo ON Alumno.rutAlum = alumno_grupo.fk_rutAlum INNER JOIN Grupo ON alumno_grupo.fk_idGru = Grupo.idGru INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru INNER JOIN Rol ON Alumno.fk_idRol = Rol.idRol Where proyecto.Folio="+folio+" and rutAlum='"+Aldba.RutAlumn+"';", con);
                        updateDBANombre.ExecuteNonQuery();
                        //PROGRAMADOR
                         SqlCommand updateProgramadorNombre = new SqlCommand("UPDATE Alumno SET nombre ='" + AlPro.Nombre + "',fk_idRol=3 FROM Alumno INNER JOIN alumno_grupo ON Alumno.rutAlum = alumno_grupo.fk_rutAlum INNER JOIN Grupo ON alumno_grupo.fk_idGru = Grupo.idGru INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru INNER JOIN Rol ON Alumno.fk_idRol = Rol.idRol Where proyecto.Folio=" + folio + " and rutAlum='"+AlPro.RutAlumn+"';", con);
                        updateProgramadorNombre.ExecuteNonQuery();
                        //JEFE PROYECTO
                        SqlCommand updateJefeProyecto = new SqlCommand("UPDATE Alumno SET nombre ='" + alJefe.Nombre + "',fk_idRol=2 FROM Alumno INNER JOIN alumno_grupo ON Alumno.rutAlum = alumno_grupo.fk_rutAlum INNER JOIN Grupo ON alumno_grupo.fk_idGru = Grupo.idGru INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru INNER JOIN Rol ON Alumno.fk_idRol = Rol.idRol Where proyecto.Folio=" + folio + " and rutAlum='"+alJefe.RutAlumn+"';", con);
                        updateJefeProyecto.ExecuteNonQuery();

                    //INGRESO DESCRIPCION PROYECTO
                    if (des.Diagrama_func!=new byte[0])
                    {                     
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "UPDATE DescrpProyecto SET link ='" + des.Link + "', identificacion ='" + des.Identificacion + "', origen ='" + des.Origen + "', afectados ='" + des.Afectados + "', justificacion ='" + des.Justificacion + "', propuesta_solucion ='" + des.Propuesta_solucion + "' FROM DescrpProyecto INNER JOIN Proyecto ON DescrpProyecto.fk_folio = Proyecto.folio where Proyecto.folio=" + folio + ";";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "UPDATE DescrpProyecto SET link ='" + des.Link + "', identificacion ='" + des.Identificacion + "', origen ='" + des.Origen + "', afectados ='" + des.Afectados + "', justificacion ='" + des.Justificacion + "', propuesta_solucion ='" + des.Propuesta_solucion + "', diagrama_func_ =@diagrama FROM DescrpProyecto INNER JOIN Proyecto ON DescrpProyecto.fk_folio = Proyecto.folio where Proyecto.folio=" + folio + ";";
                        cmd.Parameters.Add("@diagrama", SqlDbType.Image).Value = des.Diagrama_func;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                 
 
                    //ingreso Definiciones
                    SqlCommand updateDefin = new SqlCommand("UPDATE Definiciones SET definicion ='"+des.Definiciones+"' FROM Definiciones INNER JOIN DefProyecto ON Definiciones.idDef = DefProyecto.fk_idDef INNER JOIN Proyecto ON DefProyecto.fk_folio = Proyecto.folio where Proyecto.folio=" + folio+";", con);
                    updateDefin.ExecuteNonQuery();
                    estado = true;
                    con.Close();
            }
            return estado;

        }





    }

    
}
