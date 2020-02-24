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
            this._definiciones = string.Empty;
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
                if (value.Trim().Length>0)
                {
                    _link = value;
                }
                else
                {
                    throw new Exception("Debe ingresar algun Link de elevator Pitch");
                }
                
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
                if (value.Trim().Length > 0 && value.Trim().Length <= 500)
                {
                    _identificacion = value;
                }
                else
                {
                    throw new Exception("Deben haber entre 1 y 500 caracteres en indentificacion del problema");
                }
                
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
                if (value.Trim().Length>1 && value.Trim().Length<=500)
                {
                    _origen = value;

                }
                else
                {
                    throw new Exception("EL origen debe tener entre 1 a 500 caracteres, no puede ser campo nulo");
                }
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
                if (value.Trim().Length>1 && value.Trim().Length<=500)
                {
                    _afectados = value;

                }
                else
                {
                    throw new Exception("El campo 'Afectados' debe poseer entre 1 a 500 caracteres");
                }
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
                if (value.Trim().Length>1 && value.Trim().Length<=500)
                {
                    _justificacion = value;
                }
                else
                {
                    throw new Exception("El Campo 'Justificacion' debe poseer entre 1 a 500 caracteres");
                }
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
                if (value.Trim().Length>1 && value.Trim().Length<=500)
                {
                    _propuesta_solucion = value;
                }
                else
                {
                    throw new Exception("Debe ingresar alguna propuesta solucion");
                }
                
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
               if (value.Trim().Length>=1 && value.Trim().Length<=300)
                {
                    _definiciones = value;
                }
                else
                {
                    throw new Exception("El campo 'Definiciones' debe tener entre 1 o 300 caracteres");
                }
                
            }
        }
    }
}
