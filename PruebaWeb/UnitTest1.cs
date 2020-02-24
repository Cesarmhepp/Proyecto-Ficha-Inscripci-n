using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using Biblioteca.Clases;
using System.Data.SqlClient;

namespace PruebaWeb
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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

        public bool InsertarFicha(Semestre sem, Grupo grupo, Proyecto p, Alumno Aldba, Alumno AlPro, Alumno alJefe, DescrpProyecto des, TipoInnovacion ti, string def)
        {
            bool estado = false;

            if (p.Nombre.Length > 0)
            {
                try
                {
                    //ingreso a tabla semestre

                    string insert1 = "insert into Semestre(numero,año,fk_idTSem) values(" + sem.Numero + "," + sem.Año + "," + sem.Fk_idTsem + ");";
                    ejecutar(insert1);
                    //ingreso a tabla grupo
                    string insert2 = "insert into grupo(nombre,estado) values('" + grupo.Nombre + "'," + 1 + ");";
                    ejecutar(insert2);
                    //ingreso a tabla proyecto
                    string insert3 = "insert into Proyecto(nombre,fk_idDe,fk_idTneg,fk_idSuc,fk_idSem,fk_idGru)" +
                                      " values('" + p.Nombre + "'," + p.Fk_idDe + "," + p.Fk_idTneg + "," + p.Fk_idSuc + ",(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + "),(select idGru from grupo where nombre='" + grupo.Nombre + "'));";
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
                    string insertAlumnoGrupoDBA = "insert into alumno_grupo values('" + Aldba.RutAlumn + "',(select idGru from grupo where nombre='" + grupo.Nombre + "'));";
                    ejecutar(insertAlumnoGrupoDBA);
                    string insertAlumnoGrupoPROGRA = "insert into alumno_grupo values('" + AlPro.RutAlumn + "',(select idGru from grupo where nombre='" + grupo.Nombre + "'));";
                    ejecutar(insertAlumnoGrupoPROGRA);
                    string insertAlumnoGrupoJEFE = "insert into alumno_grupo values('" + alJefe.RutAlumn + "',(select idGru from grupo where nombre='" + grupo.Nombre + "'));";
                    ejecutar(insertAlumnoGrupoJEFE);

                    //INGRESO DESCRIPCION PROYECTO
                    string insertDescproyecto = "insert into descrpProyecto(link,identificacion,origen,afectados,justificacion,propuesta_solucion,diagrama_func_,estado,fk_folio) values('" + des.Link + "','" + des.Identificacion + "','" + des.Origen + "','" + des.Afectados + "','" + des.Justificacion + "','" + des.Propuesta_solucion + "','" + des.Diagrama_func + "'," + des.Estado + ",(select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "')));";
                    ejecutar(insertDescproyecto);

                    //INGRESO TIPO INNOVACION
                    string insertTp = "insert into detInnovacion (fk_folio,fk_idTinno) values((select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "'))," + ti.IdTinno + ");";
                    ejecutar(insertTp);

                    //ingreso Definiciones
                    string insertdefproc = "insert into Definiciones(definicion) values('" + def + "')";
                    ejecutar(insertdefproc);

                    //ingreso a DefProyecto
                    string insertDefProyecto = "insert into defproyecto(fk_folio,fk_idDef) values((select folio from proyecto where nombre='" + p.Nombre + "' and fk_idDe=" + p.Fk_idDe + " and fk_idTNeg=" + p.Fk_idTneg + " and fk_idSuc=" + p.Fk_idSuc + " and fk_idSem=(select idSem from semestre where numero=" + sem.Numero + " and año=" + sem.Año + ") and fk_idGru=(select idGru from grupo where nombre='" + grupo.Nombre + "')),(select idDef from definiciones where definicion='" + def + "'));";
                    ejecutar(insertDefProyecto);
                    estado = true;
                }
                catch (Exception e)
                {

                    throw new Exception("ERROR: " + e.Message);
                }

            }
            return estado;
        }
    }
}
