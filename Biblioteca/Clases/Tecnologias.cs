using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    public class Tecnologias
    {
        private int _idTec;
        private string nombre_tecnologia;
        private int fk_idTinno;

        public Tecnologias()
        {
            this._idTec = 0;
            this.nombre_tecnologia = string.Empty;
            this.fk_idTinno = 0;
        }

        public int IdTec
        {
            get
            {
                return _idTec;
            }

            set
            {
                if (value>0)
                {
                    _idTec = value;
                }
                else
                {
                    throw new Exception("Debe ingresar algun tipo de tecnologia");
                }
                
            }
        }

        public string Nombre_tecnologia
        {
            get
            {
                return nombre_tecnologia;
            }

            set
            {
                nombre_tecnologia = value;
            }
        }

        public int Fk_idTinno
        {
            get
            {
                return fk_idTinno;
            }

            set
            {
                fk_idTinno = value;
            }
        }
    }
}
