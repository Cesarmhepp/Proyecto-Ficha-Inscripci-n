﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Clases
{
    public class Alumno
    {
        private string _rutAlumn;
        private string _nombre;
        private int _dueñoIdea;
        private string _correo;
        private int _estado;
        private int _fk_idCar;
        private int _fk_idRol;
        private int _fk_idSem;
        private int _fk_idUs;

        public Alumno()
        {
            this._rutAlumn = string.Empty;
            this._nombre = string.Empty;
            this._dueñoIdea = 0;
            this._correo = string.Empty;
            this._estado = 0;
            this._fk_idCar = 0;
            this._fk_idRol = 0;
            this._fk_idSem = 0;
            this._fk_idUs = 0;
        }

        public string RutAlumn
        {
            get
            {
                return _rutAlumn;
            }

            set
            {
                if (value.Trim().Length>0)
                {
                    _rutAlumn = value;
                }
                else
                {
                    throw new Exception("Debe ingresar algun rut");
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
                if (value.Trim().Length>0)
                {
                    _nombre = value;
                }
                else
                {
                    throw new Exception("Debe ingresar algun nombre");
                }
            }
        }

        public int DueñoIdea
        {
            get
            {
                return _dueñoIdea;
            }

            set
            {
                _dueñoIdea = value;
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

        public int Fk_idCar
        {
            get
            {
                return _fk_idCar;
            }

            set
            {
                if (value>0)
                {
                    _fk_idCar = value;
                }
                else
                {
                    throw new Exception("debe ingresar alguna carrera");
                }
                
            }
        }

        public int Fk_idRol
        {
            get
            {
                return _fk_idRol;
            }

            set
            {
                if (value>0)
                {
                    _fk_idRol = value;
                }
                else
                {
                    throw new Exception("Debe ingresar alguna Rol");
                }
                
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
                if (value>0)
                {
                    _fk_idSem = value;
                }
                else
                {
                    throw new Exception("debe agregar algun semestre");
                }
                
            }
        }

        public int Fk_idUs
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
    }
}
