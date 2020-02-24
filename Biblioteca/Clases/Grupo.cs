using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    public class Grupo
    {
        private int _idGru;
        private string _nombre;
        private int _estado;

        public Grupo()
        {
            this._idGru = 0;
            this._nombre = string.Empty;
            this._estado = 0;
        }

        public int IdGru
        {
            get
            {
                return _idGru;
            }

            set
            {
                _idGru = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                if (value.Trim().Length>0)
                {
                    _nombre = value;

                }
                else
                {
                    throw new Exception("Debe ingresar algun nombre de grupo");
                }
            }
        }

        public int Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }
    }
}
