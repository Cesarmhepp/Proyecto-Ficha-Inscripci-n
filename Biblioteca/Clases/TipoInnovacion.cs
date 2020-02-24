using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    public class TipoInnovacion
    {
        private int _idTinno;
        private string _tipo;

        public TipoInnovacion()
        {
            this._idTinno = 0;
            this._tipo = string.Empty;
        }

        public int IdTinno
        {
            get
            {
                return _idTinno;
            }

            set
            {
                if (value>=1 && value<=7)
                {
                    _idTinno = value;
                }
                else
                {
                    throw new Exception("Debe seleccionar algun tipo de innovacion");
                }

            }
        }

        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                
                if (value.Trim().Length>0 && value.Trim().Length<=40)
                {                       
                    _tipo = value;
                }
                else
                {
                    throw new Exception("Debe completar el campo descriptivo si selecciono como 'otro' en tipo de innovacion");
                }
                

            }
        }
    }
}
