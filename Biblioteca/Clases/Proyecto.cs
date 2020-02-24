using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Proyecto
    {
        private int _folio;
        private string _nombre;
        private int _fk_idDe;
        private int _fk_idTneg;
        private int _fk_idSuc;
        private int _fk_idSem;
        private int _fk_idGru;
        private DescrpProyecto _dpro;
        private int _fk_idTin;
        

        public Proyecto()
        {
            this._folio = 0;
            this._nombre = string.Empty;
            this._fk_idDe = 0;
            this._fk_idTneg = 0;
            this._fk_idSuc = 0;
            this._fk_idSem = 0;
            this._fk_idGru=0;
            this._fk_idTin = 0;
            this._dpro = new DescrpProyecto();
        }

        public int Folio
        {
            get
            {
                return _folio;
            }

            set
            {
                _folio = value;
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
                    throw new Exception("Debe ingresar algun nombre de proyecto");
                }
                
            }
        }

        public int Fk_idDe
        {
            get
            {
                return _fk_idDe;
            }

            set
            {
                _fk_idDe = value;
            }
        }

        public int Fk_idTneg
        {
            get
            {
                return _fk_idTneg;
            }

            set
            {
                _fk_idTneg = value;
            }
        }

        public int Fk_idSuc
        {
            get
            {
                return _fk_idSuc;
            }

            set
            {
                _fk_idSuc = value;
            }
        }

        public int Fk_idSem
        {
            get
            {
                return _fk_idSem;
            }

            set
            {
                _fk_idSem = value;
            }
        }

        public DescrpProyecto Dpro
        {
            get
            {
                return _dpro;
            }

            set
            {
                _dpro = value;
            }
        }

        public int Fk_idGru
        {
            get
            {
                return _fk_idGru;
            }

            set
            {
                _fk_idGru = value;
            }
        }

        public int Fk_idTin
        {
            get
            {
                return _fk_idTin;
            }

            set
            {
                _fk_idTin = value;
            }
        }
    }
}
