using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    public class Docente
    {
        private string _rutDoc;
        private string _nombre;
        private string _correo;
        private string _fk_idUs;

        public string RutDoc
        {
            get
            {
                return _rutDoc;
            }

            set
            {
                _rutDoc = value;
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

        public string Correo
        {
            get
            {
                return _correo;
            }

            set
            {
                _correo = value;
            }
        }

        public string Fk_idUs
        {
            get
            {
                return _fk_idUs;
            }

            set
            {
                _fk_idUs = value;
            }
        }

        public Docente()
        {
            this.RutDoc = string.Empty;
            this.Nombre = string.Empty;
            this.Correo = string.Empty;
            this.Fk_idUs = string.Empty;
        }
    }
}
