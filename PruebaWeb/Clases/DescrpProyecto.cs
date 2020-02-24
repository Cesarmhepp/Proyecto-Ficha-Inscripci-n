using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class DescrpProyecto
    {
        private int _id;
        private string _link;
        private string _identificacion;
        private string _origen;
        private string _afectados;
        private string _justificacion;
        private string _propuesta_solucion;
        private string _definiciones;
        private byte[] _diagrama_func;
        private int _estado;
        private int fk_folio;

        public DescrpProyecto()
        {
            this._id = 0;
            this._link = string.Empty;
            this._identificacion = string.Empty;
            this._origen = string.Empty;
            this._afectados = string.Empty;
            this._justificacion = string.Empty;
            this._propuesta_solucion = string.Empty;
            this.Definiciones = string.Empty;
            this._diagrama_func = new byte[0];
            this._estado = new char();
            this.fk_folio = 0;
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Link
        {
            get
            {
                return _link;
            }

            set
            {
                _link = value;
            }
        }

        public string Identificacion
        {
            get
            {
                return _identificacion;
            }

            set
            {
                _identificacion = value;
            }
        }

        public string Origen
        {
            get
            {
                return _origen;
            }

            set
            {
                _origen = value;
            }
        }

        public string Afectados
        {
            get
            {
                return _afectados;
            }

            set
            {
                _afectados = value;
            }
        }

        public string Justificacion
        {
            get
            {
                return _justificacion;
            }

            set
            {
                _justificacion = value;
            }
        }

        public string Propuesta_solucion
        {
            get
            {
                return _propuesta_solucion;
            }

            set
            {
                _propuesta_solucion = value;
            }
        }

        public byte[] Diagrama_func
        {
            get
            {
                return _diagrama_func;
            }

            set
            {
                _diagrama_func = value;
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

        public int Fk_folio
        {
            get
            {
                return fk_folio;
            }

            set
            {
                fk_folio = value;
            }
        }

        public string Definiciones
        {
            get
            {
                return _definiciones;
            }

            set
            {
                _definiciones = value;
            }
        }
    }
}
