using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    public class TipoInnovacionNegocio
    {
        int _IdTin;
        string _nombre;

        public TipoInnovacionNegocio()
        {
            this._IdTin = 0;
            this._nombre = string.Empty;
        }

        public int IdTin
        {
            get
            {
                return _IdTin;
            }

            set
            {
                if (value>=1 && value<=3)
                {
                    _IdTin = value;
                }
                else
                {
                    throw new Exception("Debe selecionar algun tipo de Innovacion de negocio");
                }

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
                _nombre = value;
            }
        }
    }
}
