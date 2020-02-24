﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    public class Semestre
    {
        private int _idSem;
        private int _numero;
        private int _Año;
        private int _fk_idTsem;

        public Semestre()
        {
            this._idSem = 0;
            this._numero = 0;
            this._Año = 0;
            this._fk_idTsem = 0;
        }

        public int IdSem
        {
            get
            {
                return _idSem;
            }

            set
            {
                _idSem = value;
            }
        }

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (value >0)
                {
                    _numero = value;
                }
                else
                {
                    throw new Exception("Debe ingresar algun numero de semestre");
                }
                
            }
        }

        public int Año
        {
            get
            {
                return _Año;
            }

            set
            {
                if (value>0)
                {
                    if (value>2017)
                    {
                        _Año = value;

                    }
                    else
                    {
                        throw new Exception("El año de semestre debe ser mayor o igual a 2018");
                    }
                    
                }
                else
                {
                    throw new Exception("Debe agregar algun año de semestre");
                }
                
            }
        }

        public int Fk_idTsem
        {
            get
            {
                return _fk_idTsem;
            }

            set
            {
                _fk_idTsem = value;
            }
        }
    }
}
