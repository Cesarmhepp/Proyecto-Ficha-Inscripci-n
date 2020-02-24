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
                _idTinno = value;
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
                _tipo = value;
            }
        }
    }
}
